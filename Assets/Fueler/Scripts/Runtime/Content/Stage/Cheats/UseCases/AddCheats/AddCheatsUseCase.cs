using Fueler.Content.Stage.Cheats.UseCases.GetImmortality;
using Fueler.Content.Stage.Cheats.UseCases.SetImmortality;
using Fueler.Content.Stage.Cheats.UseCases.SetMaxFuel;
using Juce.Cheats.Core;
using Juce.Cheats.WidgetsInteractors;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Cheats.UseCases.AddCheats
{
    public class AddCheatsUseCase : IAddCheatsUseCase
    {
        private readonly IRepository<IWidgetInteractor> optionsDefinitionsRepository;
        private readonly ISetImmortalityUseCase setImmortalityUseCase;
        private readonly IGetImmortalityUseCase getImmortalityUseCase;
        private readonly ISetMaxFuelUseCase setMaxFuelUseCase;

        public AddCheatsUseCase(
            IRepository<IWidgetInteractor> optionsDefinitionsRepository,
            ISetImmortalityUseCase setImmortalityUseCase,
            IGetImmortalityUseCase getImmortalityUseCase,
            ISetMaxFuelUseCase setMaxFuelUseCase
            )
        {
            this.optionsDefinitionsRepository = optionsDefinitionsRepository;
            this.setImmortalityUseCase = setImmortalityUseCase;
            this.getImmortalityUseCase = getImmortalityUseCase;
            this.setMaxFuelUseCase = setMaxFuelUseCase;
        }

        public void Execute()
        {
            IWidgetInteractor immortality = JuceCheats.AddAction("Immortal", () => setImmortalityUseCase.Execute(true));
            optionsDefinitionsRepository.Add(immortality);

            IWidgetInteractor maxFuel = JuceCheats.AddAction("Set Max Fuel", setMaxFuelUseCase.Execute);
            optionsDefinitionsRepository.Add(maxFuel);
        }
    }
}
