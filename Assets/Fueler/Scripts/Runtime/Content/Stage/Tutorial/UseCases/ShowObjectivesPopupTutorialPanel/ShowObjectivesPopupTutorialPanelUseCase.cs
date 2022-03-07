using Fueler.Content.StageUi.Ui.ObjectivesPopup;
using Fueler.Content.StageUi.Ui.ObjectivesPopup.Enums;
using Juce.CoreUnity.ViewStack;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.Tutorial.UseCases.ShowObjectivesPopupTutorialPanelUseCase
{
    public class ShowObjectivesPopupTutorialPanelUseCase : IShowObjectivesPopupTutorialPanelUseCase
    {
        private readonly IUiViewStack uiViewStack;
        private readonly IObjectivesPopupUiInteractor objectivesPopupUiInteractor;

        public ShowObjectivesPopupTutorialPanelUseCase(
            IUiViewStack uiViewStack,
            IObjectivesPopupUiInteractor objectivesPopupUiInteractor
            )
        {
            this.uiViewStack = uiViewStack;
            this.objectivesPopupUiInteractor = objectivesPopupUiInteractor;
        }

        public async Task Execute(ObjectiveType objectiveType, CancellationToken cancellationToken)
        {
            objectivesPopupUiInteractor.EnableObjective(objectiveType);

            await uiViewStack.New().Show<IObjectivesPopupUiInteractor>(instantly: false).Execute(cancellationToken);

            await WaitUntilClosed(cancellationToken);
        }

        public Task WaitUntilClosed(CancellationToken cancellationToken)
        {
            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();

            Action onClosed = () =>
            {
                taskCompletionSource.TrySetResult(default);
            };

            cancellationToken.Register(onClosed);

            objectivesPopupUiInteractor.SubscribeOnClosed(onClosed);

            return taskCompletionSource.Task;
        }
    }
}
