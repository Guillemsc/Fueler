using Fueler.Content.Meta.Ui.LevelSelection.Widgets;
using Juce.CoreUnity.Factories;
using UnityEngine;

namespace Fueler.Content.Meta.Ui.LevelSelection.Factories.LevelTextButton
{
    public class LevelTextButtonWidgetFactory : MonoBehaviourKnownPrefabFactory<LevelTextButtonWidgetFactoryDefinition, LevelTextButtonWidget>
    {
        public LevelTextButtonWidgetFactory(LevelTextButtonWidget prefab,Transform parent) : base(prefab, parent)
        {

        }

        protected override void Init(LevelTextButtonWidgetFactoryDefinition definition, LevelTextButtonWidget creation)
        {
            creation.LevelNumberText.text = definition.LevelNumberText;

            creation.UnlockedContent.SetActive(!definition.Locked);
            creation.LockedContent.SetActive(definition.Locked);

            creation.SelectableCallbacks.interactable = !definition.Locked;

            creation.PointerAndSelectableSubmitCallbacks.OnSubmit += definition.OnSubmit;
        }
    }
}
