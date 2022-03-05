using Fueler.Content.StageUi.Ui.Level.Bindings;
using Juce.TweenComponent;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.SetAstronauts
{
    public class SetAstronautsUseCase : ISetAstronautsUseCase
    {
        private readonly TweenPlayer setAstronautsTween;
        private readonly TweenPlayer hideAstronautsTween;

        public SetAstronautsUseCase(
            TweenPlayer setAstronautsTween,
            TweenPlayer hideAstronautsTween
            )
        {
            this.setAstronautsTween = setAstronautsTween;
            this.hideAstronautsTween = hideAstronautsTween;
        }

        public void Execute(float totalAstronauts, float currentAstronatus)
        {
            if(totalAstronauts == 0)
            {
                hideAstronautsTween.Play();

                return;
            }

            AstronatusTweenBinding astronatusTweenBinding = new AstronatusTweenBinding()
            {
                Text = string.Format("{0}/{1}", currentAstronatus, totalAstronauts)
            };

            setAstronautsTween.Play(astronatusTweenBinding);
        }
    }
}
