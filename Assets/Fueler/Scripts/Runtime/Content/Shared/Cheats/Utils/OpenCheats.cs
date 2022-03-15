using Juce.Cheats.Core;
using UnityEngine;

namespace Fueler.Content.Shared.Cheats
{
    public class OpenCheats : MonoBehaviour
    {

#if DEVELOPMENT_BUILD || UNITY_EDITOR

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse2))
            {
                JuceCheats.Toggle();
            }
        }
#endif
    }
}