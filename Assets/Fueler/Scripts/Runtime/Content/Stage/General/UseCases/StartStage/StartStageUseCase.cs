using Fueler.Content.Shared.Time.UseCases.WaitUnscaledTime;
using Fueler.Content.StageUi.Ui.Level;
using Juce.CoreUnity.ViewStack;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.Stage.General.UseCases.StartStage
{
    public class StartStageUseCase : IStartStageUseCase
    {
        private readonly IUiViewStack uiViewStack;
        private readonly IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase;

        public StartStageUseCase(
            IUiViewStack uiViewStack,
            IWaitUnscaledTimeUseCase waitUnscaledTimeUseCase
            )
        {
            this.uiViewStack = uiViewStack;
            this.waitUnscaledTimeUseCase = waitUnscaledTimeUseCase;
        }

        public void Execute()
        {
            Run(CancellationToken.None).RunAsync();
        }

        private async Task Run(CancellationToken cancellationToken)
        {
            await waitUnscaledTimeUseCase.Execute(TimeSpan.FromSeconds(0.3f), cancellationToken);

            uiViewStack.New().Show<ILevelUiInteractor>(instantly: false).Execute();
        }
    }
}
