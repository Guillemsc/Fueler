using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.Core.Refresh;
using Juce.Core.Visibility;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.Visibles;
using JuceUnity.Core.DI.Extensions;
using UnityEngine;

namespace Fueler.Content.StageUi.Ui.EndStage
{
    public class EndStageUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<IUiViewStack>().FromServicesLocator();

            container.Bind<IVisible>()
                .FromInstance(new TweenPlayerAnimationVisible(
                    showAnimation,
                    hideAnimation
                    ));

            container.Bind<IRefreshable>()
                .FromInstance(NopRefreshable.Instance);

            container.Bind<IViewStackEntry>()
                .FromFunction(c => new ViewStackEntry(
                    typeof(IEndStageUiInteractor),
                    gameObject.transform,
                    c.Resolve<IVisible>(),
                    c.Resolve<IRefreshable>(),
                    isPopup: false
                    ));

            container.Bind<IEndStageUiInteractor>()
                .FromFunction(c => new EndStageUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(c.Resolve<IViewStackEntry>()))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(c.Resolve<IViewStackEntry>()))
                .NonLazy();
        }
    }
}
