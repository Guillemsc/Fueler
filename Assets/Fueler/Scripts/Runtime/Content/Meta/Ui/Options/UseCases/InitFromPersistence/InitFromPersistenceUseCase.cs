using Fueler.Content.Meta.Ui.Options.UseCases.UpdateInfiniteFuelOnOffText;

namespace Fueler.Content.Meta.Ui.Options.UseCases.InitFromPersistence
{
    public class InitFromPersistenceUseCase : IInitFromPersistenceUseCase
    {
        private readonly IUpdateInfiniteFuelOnOffTextUseCase updateInfiniteFuelOnOffTextUseCase;

        public InitFromPersistenceUseCase(
            IUpdateInfiniteFuelOnOffTextUseCase updateInfiniteFuelOnOffTextUseCase
            )
        {
            this.updateInfiniteFuelOnOffTextUseCase = updateInfiniteFuelOnOffTextUseCase;
        }

        public void Execute()
        {
            updateInfiniteFuelOnOffTextUseCase.Execute();
        }
    }
}
