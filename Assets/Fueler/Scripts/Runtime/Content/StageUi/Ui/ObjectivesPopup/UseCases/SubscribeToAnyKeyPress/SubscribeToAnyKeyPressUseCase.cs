using Fueler.Content.StageUi.Ui.ObjectivesPopup.UseCases.HidePanelOnAnyKeyPress;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Fueler.Content.StageUi.Ui.ObjectivesPopup.UseCases.SubscribeToAnyKeyPress
{
    public class SubscribeToAnyKeyPressUseCase : ISubscribeToAnyKeyPressUseCase
    {
        private readonly IHidePanelOnAnyKeyPressUseCase hidePanelOnAnyKeyPressUseCase;

        private InputAction anyKeyWait;

        public SubscribeToAnyKeyPressUseCase(
            IHidePanelOnAnyKeyPressUseCase hidePanelOnAnyKeyPressUseCase
            )
        {
            this.hidePanelOnAnyKeyPressUseCase = hidePanelOnAnyKeyPressUseCase;
        }

        public void Execute()
        {
            anyKeyWait = new InputAction(binding: "/*/<button>", type: InputActionType.Button);
            anyKeyWait.AddBinding("/<Gamepad>/*/*");
            anyKeyWait.performed += OnKeyPressed;

            anyKeyWait.Enable();
        }

        private void OnKeyPressed(CallbackContext callbackContext)
        {
            anyKeyWait.Disable();

            hidePanelOnAnyKeyPressUseCase.Execute();
        }
    }
}
