using Juce.CoreUnity.Ui.Frame;
using UnityEngine;

namespace Fueler.Contexts.Services
{
    public class ServicesContextInstance : MonoBehaviour
    {
        [SerializeField] private UiFrame uiFrame = default;

        public IUiFrame UiFrame => uiFrame;
    }
}
