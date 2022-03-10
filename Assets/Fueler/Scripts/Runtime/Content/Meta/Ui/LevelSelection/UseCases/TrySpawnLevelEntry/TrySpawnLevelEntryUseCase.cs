using Fueler.Content.Meta.Ui.LevelSelection.Factories.LevelTextButton;
using Fueler.Content.Meta.Ui.LevelSelection.UseCases.LevelPressed;
using Fueler.Content.Meta.Ui.LevelSelection.Widgets;
using Fueler.Content.Shared.Levels.Configuration;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;
using System;

namespace Fueler.Content.Meta.Ui.LevelSelection.UseCases.TrySpawnLevelEntry
{
    public class TrySpawnLevelEntryUseCase : ITrySpawnLevelEntryUseCase
    {
        private readonly IRepository<IDisposable<LevelTextButtonWidget>> entriesRepository;
        private readonly IFactory<LevelTextButtonWidgetFactoryDefinition, IDisposable<LevelTextButtonWidget>> entriesFactory;
        private readonly ILevelPressedUseCase levelPressedUseCase;

        public TrySpawnLevelEntryUseCase(
            IRepository<IDisposable<LevelTextButtonWidget>> entriesRepository,
            IFactory<LevelTextButtonWidgetFactoryDefinition, IDisposable<LevelTextButtonWidget>> entriesFactory,
            ILevelPressedUseCase levelPressedUseCase
            )
        {
            this.entriesRepository = entriesRepository;
            this.entriesFactory = entriesFactory;
            this.levelPressedUseCase = levelPressedUseCase;
        }

        public bool Execute(
            int index,
            bool locked,
            ILevelConfiguration levelConfiguration, 
            out LevelTextButtonWidget levelEntry
            )
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

            Action pressedAction = () => { };

            if(!locked)
            {
                pressedAction = () => levelPressedUseCase.Execute(levelConfiguration);
            }

            bool created = entriesFactory.TryCreate(
                new LevelTextButtonWidgetFactoryDefinition(
                    levelNumberText,
                    locked,
                    pressedAction
                    ),
                out IDisposable<LevelTextButtonWidget> entry
                );

            if(!created)
            {
                levelEntry = default;
                return false;
            }

            entriesRepository.Add(entry);

            levelEntry = entry.Value;
            return true;
        }
    }
}
