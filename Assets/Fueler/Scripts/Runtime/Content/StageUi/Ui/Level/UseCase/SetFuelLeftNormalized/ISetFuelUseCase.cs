namespace Fueler.Content.StageUi.Ui.Level.UseCase.SetFuel
{
    public interface ISetFuelUseCase
    {
        void Execute(float maxFuel, float currentFuel);
    }
}
