using Fueler.Content.LoadingScreen.LoadingScreenUi.UseCases.SetVisible;
using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.CoreUnity.ViewStack;
using Juce.TweenComponent;
using JuceUnity.Core.DI.Extensions;
using UnityEngine;

namespace Fueler.Content.LoadingScreen.LoadingScreenUi
{
    public class LoadingScreenUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Tweens")]
        [SerializeField] private TweenPlayer showTween = default;
        [SerializeField] private TweenPlayer hideTween = default;

        public void Install(IDIContainerBuilder container)
        {
            container.Bind<ISetVisibleUseCase>()
                 .FromFunction(c => new SetVisibleUseCase(
                     showTween,
                     hideTween
                     ));

            container.Bind<ILoadingScreenUiInteractor>()
                .FromFunction(c => new LoadingScreenUiInteractor(
                    c.Resolve<ISetVisibleUseCase>()
                    ));
        }
    }
}
