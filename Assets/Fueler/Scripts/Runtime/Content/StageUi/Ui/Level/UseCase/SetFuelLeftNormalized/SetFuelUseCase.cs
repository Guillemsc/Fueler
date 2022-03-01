using Fueler.Content.StageUi.Ui.Level.Bindings;
using Juce.TweenComponent;
using System;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.SetFuel
{
    public class SetFuelUseCase : ISetFuelUseCase
    {
        private readonly TweenPlayer setFuelTween;

        public SetFuelUseCase(
            TweenPlayer setFuelTween
            )
        {
            this.setFuelTween = setFuelTween;
        }

        public void Execute(float maxFuel, float currentFuel)
        {
            currentFuel = Math.Min(maxFuel, currentFuel);
            currentFuel = Math.Max(0, currentFuel);

            float currentFuelNormalized = 0.0f;

            if (maxFuel > 0)
            {
                currentFuelNormalized = currentFuel / maxFuel;
            }

            float ceelingMaxFuel = (float)Math.Ceiling(maxFuel);
            float ceelingCurrentFuel = (float)Math.Ceiling(currentFuel);

            FuelLeftTweenBinding fuelLeftTweenBinding = new FuelLeftTweenBinding()
            {
                FillImage = currentFuelNormalized,
                Text = string.Format("{0}/{1}", ceelingCurrentFuel, ceelingMaxFuel)
            };

            setFuelTween.Play(fuelLeftTweenBinding);
        }
    }
}
