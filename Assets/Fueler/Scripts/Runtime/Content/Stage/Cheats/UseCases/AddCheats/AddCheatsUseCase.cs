using Fueler.Content.Stage.Cheats.UseCases.GetImmortality;
using Fueler.Content.Stage.Cheats.UseCases.SetImmortality;
using Fueler.Content.Stage.Cheats.UseCases.SetMaxFuel;
using Juce.Core.Repositories;
using SRDebugger;

namespace Fueler.Content.Stage.Cheats.UseCases.AddCheats
{
    public class AddCheatsUseCase : IAddCheatsUseCase
    {
        private readonly IRepository<OptionDefinition> optionsDefinitionsRepository;
        private readonly ISetImmortalityUseCase setImmortalityUseCase;
        private readonly IGetImmortalityUseCase getImmortalityUseCase;
        private readonly ISetMaxFuelUseCase setMaxFuelUseCase;

        public AddCheatsUseCase(
            IRepository<OptionDefinition> optionsDefinitionsRepository,
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
            OptionDefinition immortality = OptionDefinition.Create(
               $"Immortality",
               getImmortalityUseCase.Execute,
               setImmortalityUseCase.Execute
               );
            SRDebug.Instance.AddOption(immortality);
            optionsDefinitionsRepository.Add(immortality);

            OptionDefinition maxFuel = OptionDefinition.FromMethod(
                $"Set Max Fuel",
                setMaxFuelUseCase.Execute
                );
            SRDebug.Instance.AddOption(maxFuel);
            optionsDefinitionsRepository.Add(maxFuel);
        }
    }
}
