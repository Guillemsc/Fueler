namespace Fueler.Content.Meta.Ui.LevelSelection.Factories.LevelTextButton
{
    public class LevelTextButtonWidgetFactoryDefinition 
    {
        public string LevelNumberText { get; }
        public bool Locked { get; }

        public LevelTextButtonWidgetFactoryDefinition(
            string levelNumberText,
            bool locked
            )
        {
            LevelNumberText = levelNumberText;
            Locked = locked;
        }
    }
}
