using Fueler.Content.StageUi.Ui.AllLevelsCompleted.UseCase.SubscribeToButtons;
using Fueler.Content.StageUi.Ui.AllLevelsCompleted.UseCases.ContinueButtonPressed;
using Fueler.Contexts.Shared.UseCases.UnloadStageAndLoadMeta;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.Ui.Others;
using Juce.CoreUnity.Ui.SelectableCallback;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.ViewStack.Entries;
using Juce.CoreUnity.Visibles;
using UnityEngine;

namespace Fueler.Content.StageUi.Ui.AllLevelsCompleted
{
    public class AllLevelsCompletedUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Selectables")]
        [SerializeField] private SelectableCallbacks firstSelectable = default;

        [Header("Buttons")]
        [SerializeField] private PointerAndSelectableSubmitCallbacks continueButton = default;

        private IViewStackEntry viewStackEntry;

        public void Install(IDIContainerBuilder container)
        {
            viewStackEntry = CreateStackEntry();

            container.Bind<IContinueButtonPressedUseCase>()
                .FromFunction(c => new ContinueButtonPressedUseCase(
                    c.Resolve<IUnloadStageAndLoadMetaUseCase>()
                    ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    continueButton,
                    c.Resolve<IContinueButtonPressedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<IAllLevelsCompletedUiInteractor>()
                .FromFunction(c => new AllLevelsCompletedUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(viewStackEntry))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(viewStackEntry))
                .NonLazy();
        }

        private IViewStackEntry CreateStackEntry()
        {
            return new ViewStackEntry(
                typeof(IAllLevelsCompletedUiInteractor),
                gameObject.transform,
                new TweenPlayerAnimationVisible(
                    showAnimation,
                    hideAnimation
                    ),
                isPopup: false,
                new ViewStackEntryRefresh(RefreshType.BeforeShow, new SetAsSelectedRefreshable(firstSelectable))
                );
        }
    }
}
