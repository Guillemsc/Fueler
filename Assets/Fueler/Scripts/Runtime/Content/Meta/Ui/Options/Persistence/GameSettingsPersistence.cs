namespace Fueler.Content.Meta.Ui.Options.Persistence
{
    [System.Serializable]
    public class GameSettingsPersistence
    {
        public static readonly string Path = "GameSettings";

        public bool Fullscreen { get; set; } = true;
        public bool AudioMusicEnabled { get; set; } = true;
        public bool AudioFxEnabled { get; set; } = true;

        public override string ToString()
        {
            return string.Format(
                "({0}-{1}) ({2}-{3}) ({4}-{5})",
                nameof(Fullscreen),
                Fullscreen,
                nameof(AudioMusicEnabled),
                AudioMusicEnabled,
                nameof(AudioFxEnabled),
                AudioFxEnabled
                );
        }
    }
}
