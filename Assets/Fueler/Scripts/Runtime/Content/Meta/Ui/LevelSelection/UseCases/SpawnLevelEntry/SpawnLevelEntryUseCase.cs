using Fueler.Content.Meta.Ui.LevelSelection.Factories.LevelTextButton;
using Fueler.Content.Meta.Ui.LevelSelection.Widgets;
using Fueler.Content.Shared.Levels.Configuration;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.SpawnLevelEntry
{
    public class SpawnLevelEntryUseCase : ISpawnLevelEntryUseCase
    {
        private readonly IRepository<IDisposable<LevelTextButtonWidget>> entriesRepository;
        private readonly IFactory<LevelTextButtonWidgetFactoryDefinition, IDisposable<LevelTextButtonWidget>> entriesFactory;

        public SpawnLevelEntryUseCase(
            IRepository<IDisposable<LevelTextButtonWidget>> entriesRepository,
            IFactory<LevelTextButtonWidgetFactoryDefinition, IDisposable<LevelTextButtonWidget>> entriesFactory
            )
        {
            this.entriesRepository = entriesRepository;
            this.entriesFactory = entriesFactory;
        }

        public void Execute(int index, ILevelConfiguration levelConfiguration)
        {
            string levelNumberText = string.Empty;

            if(index <= 9)
            {
                levelNumberText = string.Format("0{0}", index);
            }
            else
            {
                levelNumberText = index.ToString();
            }

            bool created = entriesFactory.TryCreate(
                new LevelTextButtonWidgetFactoryDefinition(
                    levelNumberText
                    ),
                out IDisposable<LevelTextButtonWidget> entry
                );

            if(!created)
            {
                return;
            }

            entriesRepository.Add(entry);
        }
    }
}
