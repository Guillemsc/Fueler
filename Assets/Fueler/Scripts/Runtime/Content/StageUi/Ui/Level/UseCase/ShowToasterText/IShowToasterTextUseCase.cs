using Fueler.Content.StageUi.Ui.Level.Enums;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.ShowToasterText
{
    public interface IShowToasterTextUseCase
    {
        void Execute(string text, ToasterTextDuration toasterTextDuration);
    }
}
