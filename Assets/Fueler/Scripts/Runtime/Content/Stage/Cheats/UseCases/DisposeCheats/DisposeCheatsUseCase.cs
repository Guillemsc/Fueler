using Juce.Core.Repositories;
using SRDebugger;

namespace Fueler.Content.Stage.Cheats.UseCases.DisposeCheats
{
    public class DisposeCheatsUseCase : IDisposeCheatsUseCase
    {
        private readonly IRepository<OptionDefinition> optionsDefinitionsRepository;

        public DisposeCheatsUseCase(
            IRepository<OptionDefinition> optionsDefinitionsRepository
            )
        {
            this.optionsDefinitionsRepository = optionsDefinitionsRepository;
        }

        public void Execute()
        {
            foreach (OptionDefinition definition in optionsDefinitionsRepository.Items)
            {
                SRDebug.Instance.RemoveOption(definition);
            }

            optionsDefinitionsRepository.Clear();
        }
    }
}
