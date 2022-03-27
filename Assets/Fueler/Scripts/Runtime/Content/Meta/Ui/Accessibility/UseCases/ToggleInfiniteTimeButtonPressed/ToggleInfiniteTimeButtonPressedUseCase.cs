using Fueler.Content.Meta.Ui.Accessibility.UseCases.UpdateInfiniteTimeToggleText;
using Fueler.Content.Stage.Accessibility.Persistence;
using Juce.Persistence.Serialization;
using System.Threading;

namespace Fueler.Content.Meta.Ui.Accessibility.UseCases.ToggleInfiniteTimeButtonPressed
{
    public class ToggleInfiniteTimeButtonPressedUseCase : IToggleInfiniteTimeButtonPressedUseCase
    {
        private readonly SerializableData<AccessibilityPersistence> accessibilitySerializable;
        private readonly IUpdateInfiniteTimeToggleTextUseCase updateInfiniteTimeToggleTextUseCase;

        public ToggleInfiniteTimeButtonPressedUseCase(
            SerializableData<AccessibilityPersistence> accessibilitySerializable,
            IUpdateInfiniteTimeToggleTextUseCase updateInfiniteTimeToggleTextUseCase
            )
        {
            this.accessibilitySerializable = accessibilitySerializable;
            this.updateInfiniteTimeToggleTextUseCase = updateInfiniteTimeToggleTextUseCase;
        }

        public void Execute()
        {
            accessibilitySerializable.Data.InfiniteTime = !accessibilitySerializable.Data.InfiniteTime;

            accessibilitySerializable.Save(CancellationToken.None).RunAsync();

            updateInfiniteTimeToggleTextUseCase.Execute();
        }
    }
}
