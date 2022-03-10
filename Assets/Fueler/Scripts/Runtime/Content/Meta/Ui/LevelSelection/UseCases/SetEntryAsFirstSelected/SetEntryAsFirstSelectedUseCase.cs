using Fueler.Content.Meta.Ui.LevelSelection.Widgets;
using Juce.Core.Repositories;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.SetEntryAsFirstSelected
{
    public class SetEntryAsFirstSelectedUseCase : ISetEntryAsFirstSelectedUseCase
    {
        private readonly ISingleRepository<LevelTextButtonWidget> firstSelectedEntryRepository;

        public SetEntryAsFirstSelectedUseCase(
            ISingleRepository<LevelTextButtonWidget> firstSelectedEntryRepository
            )
        {
            this.firstSelectedEntryRepository = firstSelectedEntryRepository;
        }

        public void Execute(LevelTextButtonWidget levelTextButtonWidget)
        {
            firstSelectedEntryRepository.Set(levelTextButtonWidget);
        }
    }
}
