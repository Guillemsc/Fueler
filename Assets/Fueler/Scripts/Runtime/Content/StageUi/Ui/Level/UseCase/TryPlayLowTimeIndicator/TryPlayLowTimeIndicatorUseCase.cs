using Juce.TweenComponent;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.TryPlayLowTimeIndicator
{
    public class TryPlayLowTimeIndicatorUseCase : ITryPlayLowTimeIndicatorUseCase
    {
        private readonly TweenPlayer lowTimeTween;

        public TryPlayLowTimeIndicatorUseCase(
            TweenPlayer lowTimeTween
            )
        {
            this.lowTimeTween = lowTimeTween;
        }

        public void Execute()
        {
            if (lowTimeTween.IsPlaying)
            {
                return;
            }

            lowTimeTween.Play();
        }
    }
}
