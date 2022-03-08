using Juce.TweenComponent;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.TryPlayLowFuelIndicator
{
    public class TryPlayLowFuelIndicatorUseCase : ITryPlayLowFuelIndicatorUseCase
    {
        private readonly float lowFuelIndicatorNormalized;
        private readonly TweenPlayer lowFuelTween;

        public TryPlayLowFuelIndicatorUseCase(
            float lowFuelIndicatorNormalized,
            TweenPlayer lowFuelTween
            )
        {
            this.lowFuelIndicatorNormalized = lowFuelIndicatorNormalized;
            this.lowFuelTween = lowFuelTween;
        }

        public void Execute(float fuelLeftNormalized)
        {
            if(lowFuelIndicatorNormalized < fuelLeftNormalized)
            {
                return;
            }

            if(lowFuelTween.IsPlaying)
            {
                return;
            }

            lowFuelTween.Play();
        }
    }
}
