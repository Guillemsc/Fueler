using Fueler.Content.StageUi.Ui.Level.Bindings;
using Fueler.Content.StageUi.Ui.Level.Enums;
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
        private readonly TimeSpan toasterTextLongTimeSpanOnScreen;
        private readonly TimeSpan toasterTextMediumTimeSpanOnScreen;
        private readonly TimeSpan toasterTextShortTimeSpanOnScreen;

        public ShowToasterTextUseCase(
            ISequencer sequencer,
            TweenPlayer showToasterTextTween,
            TweenPlayer hideToasterTextTween,
            float toasterTextLongDurationOnScreen,
            float toasterTextMediumDurationOnScreen,
            float toasterTextShortDurationOnScreen
            )
        {
            this.sequencer = sequencer;
            this.showToasterTextTween = showToasterTextTween;
            this.hideToasterTextTween = hideToasterTextTween;
            this.toasterTextLongTimeSpanOnScreen = TimeSpan.FromSeconds(toasterTextLongDurationOnScreen);
            this.toasterTextMediumTimeSpanOnScreen = TimeSpan.FromSeconds(toasterTextMediumDurationOnScreen);
            this.toasterTextShortTimeSpanOnScreen = TimeSpan.FromSeconds(toasterTextShortDurationOnScreen);
        }

        public void Execute(string text, ToasterTextDuration toasterTextDuration)
        {
            sequencer.Play(ct => PlayToasterText(text, toasterTextDuration, ct));
        }

        private async Task PlayToasterText(
            string text,
            ToasterTextDuration toasterTextDuration,
            CancellationToken cancellationToken
            )
        {
            ToasterTextTweenBinding toasterTextTweenBinding = new ToasterTextTweenBinding
            {
                Text = text,
            };

            await showToasterTextTween.Play(toasterTextTweenBinding, cancellationToken);

            ITimer timer = new ScaledUnityTimer();
            timer.Start();

            TimeSpan duration = GetDuration(toasterTextDuration);

            await timer.AwaitReach(duration, cancellationToken);

            await hideToasterTextTween.Play(cancellationToken);

            timer.Restart();
            await timer.AwaitReach(TimeSpan.FromSeconds(0.5f), cancellationToken);
        }

        private TimeSpan GetDuration(ToasterTextDuration toasterTextDuration)
        {
            switch(toasterTextDuration)
            {
                case ToasterTextDuration.Long:
                    {
                        return toasterTextLongTimeSpanOnScreen;
                    }

                case ToasterTextDuration.Medium:
                    {
                        return toasterTextMediumTimeSpanOnScreen;
                    }

                case ToasterTextDuration.Short:
                default:
                    {
                        return toasterTextShortTimeSpanOnScreen;
                    }
            }
        }
    }
}
