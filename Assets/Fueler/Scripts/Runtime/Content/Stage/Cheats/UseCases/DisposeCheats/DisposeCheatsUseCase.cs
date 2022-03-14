using Juce.Cheats.Core;
using Juce.Cheats.WidgetsInteractors;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.Cheats.UseCases.DisposeCheats
{
    public class DisposeCheatsUseCase : IDisposeCheatsUseCase
    {
        private readonly IRepository<IWidgetInteractor> optionsDefinitionsRepository;

        public DisposeCheatsUseCase(
            IRepository<IWidgetInteractor> optionsDefinitionsRepository
            )
        {
            this.optionsDefinitionsRepository = optionsDefinitionsRepository;
        }

        public void Execute()
        {
            foreach (IWidgetInteractor definition in optionsDefinitionsRepository.Items)
            {
                JuceCheats.Remove(definition);
            }

            optionsDefinitionsRepository.Clear();
        }
    }
}
