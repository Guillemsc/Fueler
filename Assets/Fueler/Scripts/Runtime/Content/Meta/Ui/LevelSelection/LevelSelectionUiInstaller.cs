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
using Fueler.Content.Meta.Ui.LevelSelection.UseCases.SpawnLevelEntry;
using Fueler.Content.Meta.Ui.LevelSelection.UseCases.SpawnLevelEntries;
using Fueler.Content.Services.Configuration;

namespace Fueler.Content.Meta.Ui.LevelSelection
{
    public class LevelSelectionUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Selectables")]
        [SerializeField] private SelectableCallbacks firstSelectable = default;

        [Header("LevelTextButtonWidget")]
        [SerializeField] private LevelTextButtonWidget levelTextButtonWidgetPrefab = default;
        [SerializeField] private Transform levelTextButtonWidgetParent = default;

        private IViewStackEntry viewStackEntry;

        public void Install(IDIContainerBuilder container)
        {
            viewStackEntry = CreateStackEntry();

            //container.Bind<ISubscribeToButtonsUseCase>()
            //    .FromFunction(c => new SubscribeToButtonsUseCase(
            //        playButton,
            //        optionsButton,
            //        quitButton,
            //        c.Resolve<IPlayButtonPressedUseCase>(),
            //        c.Resolve<IOptionsButtonPressedUseCase>(),
            //        c.Resolve<IQuitButtonPressedUseCase>()
            //        ))
            //    .WhenInit((c, o) => o.Execute())
            //    .NonLazy();

            container.Bind<IRepository<IDisposable<LevelTextButtonWidget>>>()
                .FromInstance(new SimpleRepository<IDisposable<LevelTextButtonWidget>>());

            container.Bind<IFactory<LevelTextButtonWidgetFactoryDefinition, IDisposable<LevelTextButtonWidget>>>()
                .FromInstance(new LevelTextButtonWidgetFactory(
                    levelTextButtonWidgetPrefab,
                    levelTextButtonWidgetParent
                    ));

            container.Bind<ISpawnLevelEntryUseCase>()
                .FromFunction(c => new SpawnLevelEntryUseCase(
                    c.Resolve<IRepository<IDisposable<LevelTextButtonWidget>>>(),
                    c.Resolve<IFactory<LevelTextButtonWidgetFactoryDefinition, IDisposable<LevelTextButtonWidget>>>()
                    ));

            container.Bind<ISpawnLevelEntriesUseCase>()
                .FromFunction(c => new SpawnLevelEntriesUseCase(
                    c.Resolve<IConfigurationService>().LevelsConfiguration,
                    c.Resolve<ISpawnLevelEntryUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<ILevelSelectionUiInteractor>()
                .FromFunction(c => new LevelSelectionUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(viewStackEntry))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(viewStackEntry))
                .NonLazy();
        }

        private IViewStackEntry CreateStackEntry()
        {
            return new ViewStackEntry(
                typeof(ILevelSelectionUiInteractor),
                gameObject.transform,
                new TweenPlayerAnimationVisible(
                    showAnimation,
                    hideAnimation
                    ),
                isPopup: false/*,
                new ViewStackEntryRefresh(RefreshType.BeforeShow, new SetAsSelectedRefreshable(firstSelectable))*/
                );
        }
    }
}
