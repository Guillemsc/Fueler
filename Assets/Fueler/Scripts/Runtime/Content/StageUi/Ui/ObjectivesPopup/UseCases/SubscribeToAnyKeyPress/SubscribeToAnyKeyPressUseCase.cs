using Fueler.Content.StageUi.Ui.ObjectivesPopup.UseCases.HidePanelOnAnyKeyPress;
using Juce.Input.InputActions;
using static UnityEngine.InputSystem.InputAction;

namespace Fueler.Content.StageUi.Ui.ObjectivesPopup.UseCases.SubscribeToAnyKeyPress
{
    public class SubscribeToAnyKeyPressUseCase : ISubscribeToAnyKeyPressUseCase
    {
        private readonly AnyKeyInputAction anyKeyWait;
        private readonly IHidePanelOnAnyKeyPressUseCase hidePanelOnAnyKeyPressUseCase;

        public SubscribeToAnyKeyPressUseCase(
            AnyKeyInputAction anyKeyWait,
            IHidePanelOnAnyKeyPressUseCase hidePanelOnAnyKeyPressUseCase
            )
        {
            this.anyKeyWait = anyKeyWait;
            this.hidePanelOnAnyKeyPressUseCase = hidePanelOnAnyKeyPressUseCase;
        }

        public void Execute()
        {
            anyKeyWait.InputAction.performed += OnKeyPressed;
            anyKeyWait.InputAction.Enable();
        }

        private void OnKeyPressed(CallbackContext callbackContext)
        {
            anyKeyWait.InputAction.performed -= OnKeyPressed;
            anyKeyWait.InputAction.Disable();

            hidePanelOnAnyKeyPressUseCase.Execute();
        }
    }
}
