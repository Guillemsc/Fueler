using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.Visibles;
using UnityEngine;
using Juce.CoreUnity.Ui.SelectableCallback;
using Juce.CoreUnity.ViewStack.Entries;
using Juce.Core.Refresh;
using Juce.Core.Repositories;
using Fueler.Content.Meta.Ui.LevelSelection.Widgets;
using Juce.Core.Factories;
using Fueler.Content.Meta.Ui.LevelSelection.Factories.LevelTextButton;
using Juce.Core.Disposables;
using Fueler.Content.Meta.Ui.LevelSelection.UseCases.TrySpawnLevelEntry;
using Fueler.Content.Meta.Ui.LevelSelection.UseCases.SpawnLevelEntries;
using Fueler.Content.Services.Configuration;
using Fueler.Content.Shared.Levels.UseCases.IsLevelCompleted;
using Fueler.Content.Services.Persistence;
using Fueler.Content.Meta.Ui.LevelSelection.UseCases.SetEntryAsFirstSelected;
using Fueler.Content.Meta.Ui.LevelSelection.UseCases.SubscribeToButtons;
using Fueler.Content.Meta.Ui.LevelSelection.UseCases.BackButtonPressed;
using Juce.CoreUnity.Ui.Others;
using Fueler.Content.Shared.Levels.UseCases.TryGetLastUncompletedLevel;

namespace Fueler.Content.Meta.Ui.LevelSelection
{
    public class LevelSelectionUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Selectables")]
        [SerializeField] private SelectableCallbacks firstSelectable = default;

        [Header("Buttons")]
        [SerializeField] private PointerAndSelectableSubmitCallbacks backButton = default;

        [Header("LevelTextButtonWidget")]
        [SerializeField] private LevelTextButtonWidget levelTextButtonWidgetPrefab = default;
        [SerializeField] private Transform levelTextButtonWidgetParent = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<LevelSelectionUiViewStackEntry>()
                .FromFunction(c => new LevelSelectionUiViewStackEntry(
                    typeof(ILevelSelectionUiInteractor),
                    gameObject.transform,
                    new TweenPlayerAnimationVisible(
                        showAnimation,
                        hideAnimation
                        ),
                    isPopup: false,
                    new ViewStackEntryRefresh(
                        RefreshType.BeforeShow,
                        new CallbackRefreshable(() => SelectEntry(c.Resolve<ISingleRepository<LevelTextButtonWidget>>()))
                        )
                    ));

            container.Bind<IRepository<IDisposable<LevelTextButtonWidget>>>()
                .FromInstance(new SimpleRepository<IDisposable<LevelTextButtonWidget>>());

            container.Bind<IFactory<LevelTextButtonWidgetFactoryDefinition, IDisposable<LevelTextButtonWidget>>>()
                .FromInstance(new LevelTextButtonWidgetFactory(
                    levelTextButtonWidgetPrefab,
                    levelTextButtonWidgetParent
                    ));

            container.Bind<ISingleRepository<LevelTextButtonWidget>>()
                .FromInstance(new SimpleSingleRepository<LevelTextButtonWidget>());

            container.Bind<IIsLevelCompletedUseCase>()
                .FromFunction(c => new IsLevelCompletedUseCase(
                    c.Resolve<IPersistenceService>().LevelsSerializable
                    ));

            container.Bind<ITryGetLastUncompletedLevelUseCase>()
                .FromFunction(c => new TryGetLastUncompletedLevelUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration,
                    c.Resolve<IIsLevelCompletedUseCase>()
                    ));

            container.Bind<ISetEntryAsFirstSelectedUseCase>()
                .FromFunction(c => new SetEntryAsFirstSelectedUseCase(
                    c.Resolve<ISingleRepository<LevelTextButtonWidget>>()
                    ));

            container.Bind<ITrySpawnLevelEntryUseCase>()
                .FromFunction(c => new TrySpawnLevelEntryUseCase(
                    c.Resolve<IRepository<IDisposable<LevelTextButtonWidget>>>(),
                    c.Resolve<IFactory<LevelTextButtonWidgetFactoryDefinition, IDisposable<LevelTextButtonWidget>>>()
                    ));

            container.Bind<ISpawnLevelEntriesUseCase>()
                .FromFunction(c => new SpawnLevelEntriesUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration,
                    c.Resolve<ITrySpawnLevelEntryUseCase>(),
                    c.Resolve<ISetEntryAsFirstSelectedUseCase>(),
                    c.Resolve<ITryGetLastUncompletedLevelUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IBackButtonPressedUseCase>()
                .FromFunction(c => new BackButtonPressedUseCase(
                    c.Resolve<IUiViewStack>()
                    ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    backButton,
                    c.Resolve<IBackButtonPressedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<ILevelSelectionUiInteractor>()
                .FromFunction(c => new LevelSelectionUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(c.Resolve<LevelSelectionUiViewStackEntry>()))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(c.Resolve<LevelSelectionUiViewStackEntry>()))
                .NonLazy();
        }

        private void SelectEntry(ISingleRepository<LevelTextButtonWidget> toSelectRepository)
        {
            bool hasItem = toSelectRepository.TryGet(out LevelTextButtonWidget item);

            if(!hasItem)
            {
                new SetAsSelectedRefreshable(firstSelectable).Refresh();
                return;
            }

            new SetAsSelectedRefreshable(item.SelectableCallbacks).Refresh();
        }
    }
}
