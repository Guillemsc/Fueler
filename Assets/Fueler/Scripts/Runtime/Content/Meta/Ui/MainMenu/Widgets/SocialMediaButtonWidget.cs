using Juce.CoreUnity.Ui.Others;
using UnityEngine;

namespace Fueler.Content.Meta.Ui.MainMenu.Widgets
{
    public class SocialMediaButtonWidget : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] private PointerAndSelectableSubmitCallbacks pointerAndSelectableSubmitCallbacks = default;

        [Header("Url")]
        [SerializeField] private string url = default;

        private void Awake()
        {
            pointerAndSelectableSubmitCallbacks.OnSubmit += OnSubmit;
        }

        private void OnDestroy()
        {
            pointerAndSelectableSubmitCallbacks.OnSubmit -= OnSubmit;
        }

        private void OnSubmit()
        {
            Application.OpenURL(url);
        }
    }
}
