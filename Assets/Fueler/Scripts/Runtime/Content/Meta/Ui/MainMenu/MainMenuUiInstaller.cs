using Juce.Core.DI.Builder;
using Juce.Core.DI.Installers;
using Juce.CoreUnity.Ui.Others;
using Juce.CoreUnity.TweenComponent;
using Juce.CoreUnity.ViewStack;
using Juce.CoreUnity.Visibles;
using UnityEngine;
using Juce.CoreUnity.Ui.SelectableCallback;

namespace Fueler.Content.Meta.Ui.MainMenu
{
    public class MainMenuUiInstaller : MonoBehaviour, IInstaller
    {
        [Header("Animations")]
        [SerializeField] private TweenPlayerAnimation showAnimation = default;
        [SerializeField] private TweenPlayerAnimation hideAnimation = default;

        [Header("Selectables")]
        [SerializeField] private SelectableCallbacks firstSelectable = default;

        [Header("Buttons")]
        [SerializeField] private PointerAndSelectableSubmitCallbacks playButton = default;

        private IViewStackEntry viewStackEntry;

        public void Install(IDIContainerBuilder container)
        {
            viewStackEntry = CreateStackEntry();

            container.Bind<IMainMenuUiInteractor>()
                .FromFunction(c => new MainMenuUiInteractor())
                .WhenInit((c, o) => c.Resolve<IUiViewStack>().Register(viewStackEntry))
                .WhenDispose((c, o) => c.Resolve<IUiViewStack>().Unregister(viewStackEntry))
                .NonLazy();
        }

        private IViewStackEntry CreateStackEntry()
        {
            return new ViewStackEntry(
                typeof(IMainMenuUiInteractor),
                gameObject.transform,
                new TweenPlayerAnimationVisible(
                    showAnimation,
                    hideAnimation
                    ),
                new SetAsSelectedRefreshable(firstSelectable),
                isPopup: false
                );
        }
    }
}
