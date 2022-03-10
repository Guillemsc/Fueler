using Fueler.Content.Meta.Ui.Options.UseCases.UpdateInfiniteFuelOnOffText;
using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;
using System.Threading;

namespace Fueler.Content.Meta.Ui.Options.UseCases.InfiniteFuelOnOffButtonPressed
{
    public class InfiniteFuelOnOffButtonPressedUseCase : IInfiniteFuelOnOffButtonPressedUseCase
    {
        private readonly SerializableData<AccessibilityPersistence> accessibilitySerializable;
        private readonly IUpdateInfiniteFuelOnOffTextUseCase updateInfiniteFuelOnOffTextUseCase;

        public InfiniteFuelOnOffButtonPressedUseCase(
            SerializableData<AccessibilityPersistence> accessibilitySerializable,
            IUpdateInfiniteFuelOnOffTextUseCase updateInfiniteFuelOnOffTextUseCase
            )
        {
            this.accessibilitySerializable = accessibilitySerializable;
            this.updateInfiniteFuelOnOffTextUseCase = updateInfiniteFuelOnOffTextUseCase;
        }

        public void Execute()
        {
            accessibilitySerializable.Data.InfiniteFuel = !accessibilitySerializable.Data.InfiniteFuel;

            accessibilitySerializable.Save(CancellationToken.None).RunAsync();

            updateInfiniteFuelOnOffTextUseCase.Execute();
        }
    }
}
