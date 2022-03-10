using System;

namespace Fueler.Content.Meta.Ui.LevelSelection.Factories.LevelTextButton
{
    public class LevelTextButtonWidgetFactoryDefinition 
    {
        public string LevelNumberText { get; }
        public bool Locked { get; }
        public Action OnSubmit { get; }

        public LevelTextButtonWidgetFactoryDefinition(
            string levelNumberText,
            bool locked,
            Action onSubmit
            )
        {
            LevelNumberText = levelNumberText;
            Locked = locked;
            OnSubmit = onSubmit;
        }
    }
}
