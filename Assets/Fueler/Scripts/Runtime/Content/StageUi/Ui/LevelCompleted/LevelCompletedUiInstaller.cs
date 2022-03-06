using Fueler.Content.Meta.Ui.LevelCompleted.UseCases.BackToMainMenuButtonPressed;
using Fueler.Content.Meta.Ui.LevelCompleted.UseCases.ContinueButtonPressed;
using Fueler.Content.Meta.Ui.LevelCompleted.UseCases.SubscribeToButtons;
using Fueler.Content.Meta.Ui.LevelCompleted.UseCases.TryAgainButtonPressed;
using Fueler.Content.Shared.Levels.UseCases.LoadNextLevel;
using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Fueler.Contexts.Shared.UseCases.UnloadStageAndLoadMeta;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Refresh;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.Ui.Others;
using Juce.CoreUnity.Ui.SelectableCallback;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.Visibles;
using UnityEngine;

namespace Fueler.Content.StageUi.Ui.LevelCompleted
{
    public class LevelCompletedUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Selectables")]
        [SerializeField] private SelectableCallbacks firstSelectable = default;

        [Header("Buttons")]
        [SerializeField] private PointerAndSelectableSubmitCallbacks continueButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks tryAgainButton = default;
        [SerializeField] private PointerAndSelectableSubmitCallbacks backToMainMenuButton = default;

        private IViewStackEntry viewStackEntry;

        public void Install(IDIContainerBuilder container)
        {
            viewStackEntry = CreateStackEntry();

            container.Bind<IContinueButtonPressedUseCase>()
                .FromFunction(c => new ContinueButtonPressedUseCase(
                    c.Resolve<ILoadNextLevelUseCase>()
                    ));

            container.Bind<ITryAgainButtonPressedUseCase>()
                .FromFunction(c => new TryAgainButtonPressedUseCase(
                 c.Resolve<IReloadLevelUseCase>()
                 ));

            container.Bind<IBackToMainMenuButtonPressedUseCase>()
                .FromFunction(c => new BackToMainMenuButtonPressedUseCase(
                    c.Resolve<IUnloadStageAndLoadMetaUseCase>()
                    ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    continueButton,
                    tryAgainButton,
                    backToMainMenuButton,
                    c.Resolve<IContinueButtonPressedUseCase>(),
                    c.Resolve<ITryAgainButtonPressedUseCase>(),
                    c.Resolve<IBackToMainMenuButtonPressedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<ILevelCompletedUiInteractor>()
                .FromFunction(c => new LevelCompletedUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(viewStackEntry))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(viewStackEntry))
                .NonLazy();
        }

        private IViewStackEntry CreateStackEntry()
        {
            return new ViewStackEntry(
                typeof(ILevelCompletedUiInteractor),
                gameObject.transform,
                new TweenPlayerAnimationVisible(
                    showAnimation,
                    hideAnimation
                    ),
                new SetAsSelectedRefreshable(firstSelectable),
                NopRefreshable.Instance,
                isPopup : false
                );
        }
    }
}
