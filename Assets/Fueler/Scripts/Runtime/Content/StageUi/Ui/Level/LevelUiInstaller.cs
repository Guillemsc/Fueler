using Fueler.Content.Shared.Levels.Configuration;
using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Fueler.Content.StageUi.Ui.Level.UseCase.SetFuel;
using Fueler.Content.StageUi.Ui.Level.UseCase.SubscribeToButtons;
using Fueler.Contexts.Shared.UseCases.UnloadAndLoadStage;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Refresh;
using Juce.CoreUnity.PointerCallback;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.ViewStack;
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

        [Header("Tween")]
        [SerializeField] private TweenPlayer setFuelTween = default;

        [Header("Buttons")]
        [SerializeField] private PointerCallbacks replayPointerCallbacks = default;

        private IViewStackEntry viewStackEntry;

        public void Install(IDIContainerBuilder container)
        {
            viewStackEntry = CreateStackEntry();

            container.Bind<ISetFuelUseCase>()
                .FromFunction(c => new SetFuelUseCase(
                    setFuelTween
                    ));

            container.Bind<ISubscribeToButtonsUseCase>()
                .FromFunction(c => new SubscribeToButtonsUseCase(
                    replayPointerCallbacks,
                    c.Resolve<IReloadLevelUseCase>()
                    ))
                .WhenInit((c, o) => o.Execute())
                .NonLazy();

            container.Bind<ILevelUiInteractor>()
                .FromFunction(c => new LevelUiInteractor(
                    c.Resolve<ISetFuelUseCase>()
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
                NopRefreshable.Instance,
                isPopup: false
                );
        }
    }
}
