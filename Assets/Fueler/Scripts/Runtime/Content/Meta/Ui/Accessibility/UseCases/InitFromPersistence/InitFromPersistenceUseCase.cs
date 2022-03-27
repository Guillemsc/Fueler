using Fueler.Content.Meta.Ui.Accessibility.UseCases.UpdateInfiniteFuelToggleText;
using Fueler.Content.Meta.Ui.Accessibility.UseCases.UpdateInfiniteTimeToggleText;

namespace Fueler.Content.Meta.Ui.Accessibility.UseCases.InitFromPersistence
{
    public class InitFromPersistenceUseCase : IInitFromPersistenceUseCase
    {
        private readonly IUpdateInfiniteFuelToggleTextUseCase updateInfiniteFuelToggleTextUseCase;
        private readonly IUpdateInfiniteTimeToggleTextUseCase updateInfiniteTimeToggleTextUseCase;

        public InitFromPersistenceUseCase(
            IUpdateInfiniteFuelToggleTextUseCase updateInfiniteFuelToggleTextUseCase,
            IUpdateInfiniteTimeToggleTextUseCase updateInfiniteTimeToggleTextUseCase
            )
        {
            this.updateInfiniteFuelToggleTextUseCase = updateInfiniteFuelToggleTextUseCase;
            this.updateInfiniteTimeToggleTextUseCase = updateInfiniteTimeToggleTextUseCase;
        }

        public void Execute()
        {
            updateInfiniteFuelToggleTextUseCase.Execute();
            updateInfiniteTimeToggleTextUseCase.Execute();
        }
    }
}
