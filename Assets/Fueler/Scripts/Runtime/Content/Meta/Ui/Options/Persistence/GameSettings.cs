namespace Fueler.Content.Meta.Ui.Options.Persistence
{
    [System.Serializable]
    public class GameSettings
    {
        public static readonly string Path = "GameSettings";

        public bool Fullscreen { get; set; } = true;
        public bool AudioEnabled { get; set; } = true;

        public override string ToString()
        {
            return string.Format(
                "({0}-{1}) ({2}-{3})",
                nameof(Fullscreen),
                Fullscreen,
                nameof(AudioEnabled),
                AudioEnabled
                );
        }
    }
}
