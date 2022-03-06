using SRDebugger;
using UnityEngine;

namespace Fueler.Content.Shared.Cheats
{
    public class OpenCheats : MonoBehaviour
    {

#if DEVELOPMENT_BUILD || UNITY_EDITOR

        private void Awake()
        {
            SRDebug.Init();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                SRDebug.Instance.ShowDebugPanel(DefaultTabs.Options);
            }
        }
#endif
    }
}