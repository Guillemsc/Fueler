using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;

namespace Fueler.Content.Meta.Ui.Options.UseCases.UpdateInfiniteFuelOnOffText
{
    public class UpdateInfiniteFuelOnOffTextUseCase : IUpdateInfiniteFuelOnOffTextUseCase
    {
        private readonly SerializableData<AccessibilityPersistence> accessibilitySerializable;
        private readonly TMPro.TextMeshProUGUI infiniteFuelOnOffText;
        private readonly string infiniteFuelTextOn;
        private readonly string infiniteFuelTextOff;

        public UpdateInfiniteFuelOnOffTextUseCase(
            SerializableData<AccessibilityPersistence> accessibilitySerializable,
            TMPro.TextMeshProUGUI infiniteFuelOnOffText,
            string infiniteFuelTextOn,
            string infiniteFuelTextOff
            )
        {
            this.accessibilitySerializable = accessibilitySerializable;
            this.infiniteFuelOnOffText = infiniteFuelOnOffText;
            this.infiniteFuelTextOn = infiniteFuelTextOn;
            this.infiniteFuelTextOff = infiniteFuelTextOff;
        }

        public void Execute()
        {
            infiniteFuelOnOffText.text = accessibilitySerializable.Data.InfiniteFuel ?
                infiniteFuelTextOn : infiniteFuelTextOff;
        }
    }
}
