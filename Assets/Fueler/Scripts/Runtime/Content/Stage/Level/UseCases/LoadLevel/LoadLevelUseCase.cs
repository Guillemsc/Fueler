using Fueler.Content.Stage.General.Entities;
using Fueler.Content.Stage.General.Factories;
using Juce.Core.Disposables;
using Juce.Core.Factories;
using Juce.Core.Repositories;

namespace Fueler.Content.Stage.General.UseCases.LoadLevel
{
    public class LoadLevelUseCase : ILoadLevelUseCase
    {
        private readonly IFactory<LevelEntityFactoryDefinition, IDisposable<LevelEntity>> levelEntityFactory;
        private readonly ISingleRepository<IDisposable<LevelEntity>> levelEntityRepository;

        public LoadLevelUseCase(
            IFactory<LevelEntityFactoryDefinition, IDisposable<LevelEntity>> levelEntityFactory,
            ISingleRepository<IDisposable<LevelEntity>> levelEntityRepository
            )
        {
            this.levelEntityFactory = levelEntityFactory;
            this.levelEntityRepository = levelEntityRepository;
        }

        public bool Execute(LevelEntity levelEntityPrefab, out LevelEntity levelEntity)
        {
            if(levelEntityRepository.HasItem)
            {
                UnityEngine.Debug.LogError("There was already a level loaded");
                levelEntity = default;
                return false;
            }

            bool created = levelEntityFactory.TryCreate(
                new LevelEntityFactoryDefinition(levelEntityPrefab),
                out IDisposable<LevelEntity> loadedLevelEntity
                );

            if(!created)
            {
                levelEntity = default;
                return false;
            }

            levelEntityRepository.Set(loadedLevelEntity);

            levelEntity = loadedLevelEntity.Value;
            return true;
        }
    }
}
