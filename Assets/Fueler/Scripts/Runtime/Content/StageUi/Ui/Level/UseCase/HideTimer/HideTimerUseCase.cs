using Juce.TweenComponent;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.HideTimer
{
    public class HideTimerUseCase : IHideTimerUseCase
    {
        private readonly TweenPlayer hideTimerTween;

        public HideTimerUseCase(
            TweenPlayer hideTimerTween
            )
        {
            this.hideTimerTween = hideTimerTween;
        }

        public void Execute()
        {
            hideTimerTween.Play();
        }
    }
}
