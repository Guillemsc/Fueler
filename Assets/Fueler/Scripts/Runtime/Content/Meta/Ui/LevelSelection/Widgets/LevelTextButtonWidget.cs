using UnityEngine;

namespace Fueler.Content.Meta.Ui.LevelSelection.Widgets
{
    public class LevelTextButtonWidget : MonoBehaviour
    {
        [SerializeField] private GameObject unlockedContent = default;
        [SerializeField] private GameObject lockedContent = default;
        [SerializeField] private TMPro.TextMeshProUGUI levelNumberText = default;

        public GameObject UnlockedContent => unlockedContent;
        public GameObject LockedContent => lockedContent;
        public TMPro.TextMeshProUGUI LevelNumberText => levelNumberText;
    }
}
