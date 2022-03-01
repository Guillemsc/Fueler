using Fueler.Content.Shared.Levels.UseCases.ReloadLevel;
using Juce.CoreUnity.PointerCallback;
using UnityEngine.EventSystems;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.SubscribeToButtons
{
    public class SubscribeToButtonsUseCase : ISubscribeToButtonsUseCase
    {
        private readonly PointerCallbacks replayPointerCallbacks;
        private readonly IReloadLevelUseCase reloadLevelUseCase;

        public SubscribeToButtonsUseCase(
            PointerCallbacks replayPointerCallbacks,
            IReloadLevelUseCase reloadLevelUseCase
            )
        {
            this.replayPointerCallbacks = replayPointerCallbacks;
            this.reloadLevelUseCase = reloadLevelUseCase;
        }

        public void Execute()
        {
            replayPointerCallbacks.OnClick += OnReplayPointerCallbacksClick;
        }

        private void OnReplayPointerCallbacksClick(PointerCallbacks pointerCallbacks, PointerEventData pointerEventData)
        {
            reloadLevelUseCase.Execute();
        }
    }
}
