using Fueler.Content.StageUi.Ui.Level.Bindings;
using Juce.TweenComponent;
using System;

namespace Fueler.Content.StageUi.Ui.Level.UseCase.SetTimerTime
{
    public class SetTimerTimeUseCase : ISetTimerTimeUseCase
    {
        private readonly TweenPlayer setTimerTimeTween;

        public SetTimerTimeUseCase(
            TweenPlayer setTimerTimeTween
            )
        {
            this.setTimerTimeTween = setTimerTimeTween;
        }

        public void Execute(int time)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            string text = timeSpan.ToString(@"mm\:ss");

            TimerTimeTweenBinding timerTimeTweenBinding = new TimerTimeTweenBinding()
            {
                Text = text,
            };

            setTimerTimeTween.Play(timerTimeTweenBinding);
        }
    }
}
