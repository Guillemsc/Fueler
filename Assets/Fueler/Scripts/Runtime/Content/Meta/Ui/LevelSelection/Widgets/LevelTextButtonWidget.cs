using Juce.CoreUnity.Ui.Others;
using Juce.CoreUnity.Ui.SelectableCallback;
using UnityEngine;

namespace Fueler.Content.Meta.Ui.LevelSelection.Widgets
{
    public class LevelTextButtonWidget : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private PointerAndSelectableSubmitCallbacks pointerAndSelectableSubmitCallbacks = default;
        [SerializeField] private SelectableCallbacks selectableCallbacks = default;

        [Header("Content")]
        [SerializeField] private GameObject unlockedContent = default;
        [SerializeField] private GameObject lockedContent = default;
        [SerializeField] private TMPro.TextMeshProUGUI levelNumberText = default;

        public SelectableCallbacks SelectableCallbacks => selectableCallbacks;
        public GameObject UnlockedContent => unlockedContent;
        public GameObject LockedContent => lockedContent;
        public TMPro.TextMeshProUGUI LevelNumberText => levelNumberText;
    }
}
