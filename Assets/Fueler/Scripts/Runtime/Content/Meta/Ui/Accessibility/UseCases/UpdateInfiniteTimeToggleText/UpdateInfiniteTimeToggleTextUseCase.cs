using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;

namespace Fueler.Content.Meta.Ui.Accessibility.UseCases.UpdateInfiniteTimeToggleText
{
    public class UpdateInfiniteTimeToggleTextUseCase : IUpdateInfiniteTimeToggleTextUseCase
    {
        private readonly SerializableData<AccessibilityPersistence> accessibilitySerializable;
        private readonly TMPro.TextMeshProUGUI text;
        private readonly string enabledText;
        private readonly string disabledText;

        public UpdateInfiniteTimeToggleTextUseCase(
            SerializableData<AccessibilityPersistence> accessibilitySerializable,
            TMPro.TextMeshProUGUI text,
            string enabledText,
            string disabledText
            )
        {
            this.accessibilitySerializable = accessibilitySerializable;
            this.text = text;
            this.enabledText = enabledText;
            this.disabledText = disabledText;
        }

        public void Execute()
        {
            text.text = accessibilitySerializable.Data.InfiniteTime ?
                enabledText : disabledText;
        }
    }
}
