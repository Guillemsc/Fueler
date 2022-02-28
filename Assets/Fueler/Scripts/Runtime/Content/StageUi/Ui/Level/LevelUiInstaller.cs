using Fueler.Content.StageUi.Ui.Level.UseCase.SetFuelLeftNormalized;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Refresh;
using Juce.Core.Visibility;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.Visibles;
using Juce.TweenComponent;
using JuceUnity.Core.DI.Extensions;
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

        private IViewStackEntry viewStackEntry;

        public void Install(IDIContainerBuilder container)
        {
            viewStackEntry = CreateStackEntry();

            container.Bind<ISetFuelLeftNormalizedUseCase>()
                .FromFunction(c => new SetFuelLeftNormalizedUseCase(
                    setFuelTween
                    ));

            container.Bind<ILevelUiInteractor>()
                .FromFunction(c => new LevelUiInteractor(
                    c.Resolve<ISetFuelLeftNormalizedUseCase>()
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
