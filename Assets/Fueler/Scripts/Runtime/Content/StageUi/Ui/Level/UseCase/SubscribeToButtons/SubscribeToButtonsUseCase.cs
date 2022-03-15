using Fueler.Content.StageUi.Ui.Level.UseCase.RestartLevelButtonPressed;
using Juce.CoreUnity.PointerCallback;
using UnityEngine.EventSystems;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerCallbacks replayPointerCallbacks;
        private readonly IRestartLevelButtonPressedUseCase restartLevelButtonPressedUseCase;

        public SubscribeToButtonsUseCase(
            PointerCallbacks replayPointerCallbacks,
            IRestartLevelButtonPressedUseCase restartLevelButtonPressedUseCase
            )
        {
            this.replayPointerCallbacks = replayPointerCallbacks;
            this.restartLevelButtonPressedUseCase = restartLevelButtonPressedUseCase;
        }

        public void Execute()
        {
            replayPointerCallbacks.OnClick += OnReplayPointerCallbacksClick;
        }

        private void OnReplayPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            restartLevelButtonPressedUseCase.Execute();
        }
    }
}
