using Fueler.Content.StageUi.Ui.Level.Bindings;
using Juce.TweenComponent;
using System;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.SetFuelLeftNormalized
{
    public class SetFuelLeftNormalizedUseCase : ISetFuelLeftNormalizedUseCase
    {
        private readonly TweenPlayer setFuelTween;

        public SetFuelLeftNormalizedUseCase(
            TweenPlayer setFuelTween
            )
        {
            this.setFuelTween = setFuelTween;
        }

        public void Execute(float fuelNormalized)
        {
            int fuelPercentage = (int)Math.Ceiling(fuelNormalized * 100f);

            FuelLeftTweenBinding fuelLeftTweenBinding = new FuelLeftTweenBinding()
            {
                FillImage = fuelNormalized,
                Text = string.Format("{0}/100", fuelPercentage)
            };

            setFuelTween.Play(fuelLeftTweenBinding);
        }
    }
}
