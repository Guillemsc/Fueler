using Fueler.Content.Meta.Ui.Options.UseCases.UpdateAudioFxToggleText;
using Fueler.Content.Meta.Ui.Options.UseCases.UpdateAudioMusicToggleText;

namespace Fueler.Content.Meta.Ui.Options.UseCases.InitFromPersistence
{
    public class InitFromPersistenceUseCase : IInitFromPersistenceUseCase
    {
        private readonly IUpdateAudioFxToggleTextUseCase updateAudioFxToggleTextUseCase;
        private readonly IUpdateAudioMusicToggleTextUseCase updateAudioMusicToggleTextUseCase;

        public InitFromPersistenceUseCase(
            IUpdateAudioFxToggleTextUseCase updateAudioFxToggleTextUseCase,
            IUpdateAudioMusicToggleTextUseCase updateAudioMusicToggleTextUseCase
            )
        {
            this.updateAudioFxToggleTextUseCase = updateAudioFxToggleTextUseCase;
            this.updateAudioMusicToggleTextUseCase = updateAudioMusicToggleTextUseCase;
        }

        public void Execute()
        {
            updateAudioFxToggleTextUseCase.Execute();
            updateAudioMusicToggleTextUseCase.Execute();
        }
    }
}
