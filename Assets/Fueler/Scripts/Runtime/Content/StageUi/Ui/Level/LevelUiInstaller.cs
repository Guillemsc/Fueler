using Fueler.Content.StageUi.Ui.Level.Events;
using Fueler.Content.StageUi.Ui.Level.UseCase.HideTimer;
using Fueler.Content.StageUi.Ui.Level.UseCase.RestartLevelButtonPressed;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetAstronauts;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetFuel;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetTimerTime;
using Fueler.Content.StageUi.Ui.Level.UseCase.ShowToasterText;
using Fueler.Content.StageUi.Ui.Level.UseCase.SubscribeToButtons;
using Fueler.Content.StageUi.Ui.Level.UseCase.TryPlayLowFuelIndicator;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Sequencing;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.ViewStack.Entries;
using Juce.CoreUnity.Visibles;
using Juce.TweenComponent;
using UnityEngine;

namespace Fueler.Content.StageUi.Ui.Level
{
    public class LevelUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Buttons")]
        [SerializeField] private PointerCallbacks replayPointerCallbacks = default;

        [Header("Fuel Tweens")]
        [SerializeField] private TweenPlayer setFuelTween = default;
        [SerializeField] private TweenPlayer lowFuelTween = default;
        [SerializeField] private TweenPlayer hideFuelTween = default;

        [Header("Astronatus Tweens")]
        [SerializeField] private TweenPlayer setAstronautsTween = default;
        [SerializeField] private TweenPlayer hideAstronautsTween = default;

        [Header("Timer Tweens")]
        [SerializeField] private TweenPlayer setTimerTimeTween = default;
        [SerializeField] private TweenPlayer hideTimerTween = default;

        [Header("Toaster Text Tweens")]
        [SerializeField] private TweenPlayer showToasterTextTween = default;
        [SerializeField] private TweenPlayer hideToasterTextTween = default;

        [Header("Toaster Text Values")]
        [SerializeField, Min(0f)] private float toasterTextDurationOnScreen = 1f;

        private IViewStackEntry viewStackEntry;

        public void Install(IDIContainerBuilder container)
        {
            viewStackEntry = CreateStackEntry();

            container.Bind<LevelUiEvents>().FromNew();

            container.Bind<ITryPlayLowFuelIndicatorUseCase>()
                .FromFunction(c => new TryPlayLowFuelIndicatorUseCase(
                    lowFuelTween
                    ));

            container.Bind<ISetFuelUseCase>()
                .FromFunction(c => new SetFuelUseCase(
                    setFuelTween,
                    hideFuelTween
                    ));

            container.Bind<ISetAstronautsUseCase>()
                .FromFunction(c => new SetAstronautsUseCase(
                    setAstronautsTween,
                    hideAstronautsTween
                    ));

            container.Bind<ISetTimerTimeUseCase>()
                .FromFunction(c => new SetTimerTimeUseCase(
                    setTimerTimeTween
                    ));

            container.Bind<IHideTimerUseCase>()
                .FromFunction(c => new HideTimerUseCase(
                    hideTimerTween
                    ));

            container.Bind<IShowToasterTextUseCase>()
                .FromFunction(c => new ShowToasterTextUseCase(
                    new Sequencer(),
                    showToasterTextTween,
                    hideToasterTextTween,
                    toasterTextDurationOnScreen
                    ));

            container.Bind<IRestartLevelButtonPressedUseCase>()
                .FromFunction(c => new RestartLevelButtonPressedUseCase(
                    c.Resolve<LevelUiEvents>()
                    ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    replayPointerCallbacks,
                    c.Resolve<IRestartLevelButtonPressedUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<ILevelUiInteractor>()
                .FromFunction(c => new LevelUiInteractor(
                    c.Resolve<LevelUiEvents>(),
                    c.Resolve<ISetFuelUseCase>(),
                    c.Resolve<ITryPlayLowFuelIndicatorUseCase>(),
                    c.Resolve<ISetAstronautsUseCase>(),
                    c.Resolve<ISetTimerTimeUseCase>(),
                    c.Resolve<IHideTimerUseCase>(),
                    c.Resolve<IShowToasterTextUseCase>()
                    ))
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(viewStackEntry))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(viewStackEntry))
                .NonLazy();
        }

        private IViewStackEntry CreateStackEntry()
        {
            return new ViewStackEntry(
                typeof(ILevelUiInteractor),
                gameObject.transform,
                new TweenPlayerAnimationVisible(
                    showAnimation,
                    hideAnimation
                    ),
                isPopup: false
                );
        }
    }
}
