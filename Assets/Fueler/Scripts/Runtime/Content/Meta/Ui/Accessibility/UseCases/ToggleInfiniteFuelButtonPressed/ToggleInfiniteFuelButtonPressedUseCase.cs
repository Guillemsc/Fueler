using Fueler.Content.Meta.Ui.Accessibility.UseCases.UpdateInfiniteFuelToggleText;
using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;
using System.Threading;

namespace Fueler.Content.Meta.Ui.Accessibility.UseCases.ToggleInfiniteFuelButtonPressed
{
    public class ToggleInfiniteFuelButtonPressedUseCase : IToggleInfiniteFuelButtonPressedUseCase
    {
        private readonly SerializableData<AccessibilityPersistence> accessibilitySerializable;
        private readonly IUpdateInfiniteFuelToggleTextUseCase updateInfiniteFuelToggleTextUseCase;

        public ToggleInfiniteFuelButtonPressedUseCase(
            SerializableData<AccessibilityPersistence> accessibilitySerializable,
            IUpdateInfiniteFuelToggleTextUseCase updateInfiniteFuelToggleTextUseCase
            )
        {
            this.accessibilitySerializable = accessibilitySerializable;
            this.updateInfiniteFuelToggleTextUseCase = updateInfiniteFuelToggleTextUseCase;
        }

        public void Execute()
        {
            accessibilitySerializable.Data.InfiniteFuel = !accessibilitySerializable.Data.InfiniteFuel;

            accessibilitySerializable.Save(CancellationToken.None).RunAsync();

            updateInfiniteFuelToggleTextUseCase.Execute();
        }
    }
}
