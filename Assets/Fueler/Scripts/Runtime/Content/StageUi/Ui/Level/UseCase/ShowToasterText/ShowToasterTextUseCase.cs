using Fueler.Content.StageUi.Ui.Level.Bindings;
using Juce.Core.Sequencing;
using Juce.Core.Time;
using Juce.CoreUnity.Time;
using Juce.TweenComponent;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.ShowToasterText
{
    public class ShowToasterTextUseCase : IShowToasterTextUseCase
    {
        private readonly ISequencer sequencer;
        private readonly TweenPlayer showToasterTextTween;
        private readonly TweenPlayer hideToasterTextTween;
        private readonly TimeSpan toasterTextTimeSpanOnScreen;

        public ShowToasterTextUseCase(
            ISequencer sequencer,
            TweenPlayer showToasterTextTween,
            TweenPlayer hideToasterTextTween,
            float toasterTextDurationOnScreen
            )
        {
            this.sequencer = sequencer;
            this.showToasterTextTween = showToasterTextTween;
            this.hideToasterTextTween = hideToasterTextTween;
            this.toasterTextTimeSpanOnScreen = TimeSpan.FromSeconds(toasterTextDurationOnScreen);
        }

        public void Execute(string text)
        {
            sequencer.Play(ct => PlayToasterText(text, ct));
        }

        private async Task PlayToasterText(string text, CancellationToken cancellationToken)
        {
            ToasterTextTweenBinding toasterTextTweenBinding = new ToasterTextTweenBinding
            {
                Text = text,
            };

            await showToasterTextTween.Play(toasterTextTweenBinding, cancellationToken);

            ITimer timer = new ScaledUnityTimer();
            timer.Start();

            await timer.AwaitReach(toasterTextTimeSpanOnScreen, cancellationToken);

            await hideToasterTextTween.Play(cancellationToken);

            timer.Restart();
            await timer.AwaitReach(TimeSpan.FromSeconds(2), cancellationToken);
        }
    }
}
