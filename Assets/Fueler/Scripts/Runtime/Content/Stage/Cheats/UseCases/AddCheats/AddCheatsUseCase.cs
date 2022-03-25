using Fueler.Content.Stage.Cheats.UseCases.GetImmortality;
using Fueler.Content.Stage.Cheats.UseCases.NextLevel;
using Fueler.Content.Stage.Cheats.UseCases.PreviousLevel;
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
        private readonly INextLevelUseCase nextLevelUseCase;
        private readonly IPreviousLevelUseCase previousLevelUseCase;

        public AddCheatsUseCase(
            IRepository<IWidgetInteractor> optionsDefinitionsRepository,
            ISetImmortalityUseCase setImmortalityUseCase,
            IGetImmortalityUseCase getImmortalityUseCase,
            ISetMaxFuelUseCase setMaxFuelUseCase,
            INextLevelUseCase nextLevelUseCase,
            IPreviousLevelUseCase previousLevelUseCase
            )
        {
            this.optionsDefinitionsRepository = optionsDefinitionsRepository;
            this.setImmortalityUseCase = setImmortalityUseCase;
            this.getImmortalityUseCase = getImmortalityUseCase;
            this.setMaxFuelUseCase = setMaxFuelUseCase;
            this.nextLevelUseCase = nextLevelUseCase;
            this.previousLevelUseCase = previousLevelUseCase;
        }

        public void Execute()
        {
            IWidgetInteractor immortality = JuceCheats.AddToggle(
                "Immortal", 
                () => getImmortalityUseCase.Execute(),
                (bool value) => setImmortalityUseCase.Execute(value)
                );
            optionsDefinitionsRepository.Add(immortality);

            IWidgetInteractor maxFuel = JuceCheats.AddAction("Set Max Fuel", setMaxFuelUseCase.Execute);
            optionsDefinitionsRepository.Add(maxFuel);

            IWidgetInteractor previousLevel = JuceCheats.AddAction("Previous Level", previousLevelUseCase.Execute);
            optionsDefinitionsRepository.Add(previousLevel);

            IWidgetInteractor nextLevel = JuceCheats.AddAction("Next Level", nextLevelUseCase.Execute);
            optionsDefinitionsRepository.Add(nextLevel);
        }
    }
}
