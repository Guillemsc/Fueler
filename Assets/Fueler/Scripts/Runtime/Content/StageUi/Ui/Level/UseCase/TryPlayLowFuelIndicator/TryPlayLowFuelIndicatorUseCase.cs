using Juce.TweenComponent;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.TryPlayLowFuelIndicator
{
    public class TryPlayLowFuelIndicatorUseCase : ITryPlayLowFuelIndicatorUseCase
    {
        private readonly TweenPlayer lowFuelTween;

        public TryPlayLowFuelIndicatorUseCase(
            TweenPlayer lowFuelTween
            )
        {
            this.lowFuelTween = lowFuelTween;
        }

        public void Execute()
        {
            if(lowFuelTween.IsPlaying)
            {
                return;
            }

            lowFuelTween.Play();
        }
    }
}
