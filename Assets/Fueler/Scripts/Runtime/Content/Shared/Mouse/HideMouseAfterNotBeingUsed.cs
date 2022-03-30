using Juce.Core.Time;
using Juce.CoreUnity.Time;
using System;
using UnityEngine;

namespace Fueler.Content.Shared.Mouse
{
    public class HideMouseAfterNotBeingUsed : MonoBehaviour
    {
        [SerializeField, Min(0)] private float hideAfterTime = 5;

        private readonly ITimer timer = new UnscaledUnityTimer();

        private Vector2 lastMousePosition;

        private void Awake()
        {
            TryShowMouse();
            SetMouseVisible(false);
        }

        private void Update()
        {
            TryShowMouse();
            TryHideMouse();
        }

        private void SetMouseVisible(bool visible)
        {
            Cursor.visible = visible;
        }

        private void TryShowMouse()
        {
            UnityEngine.InputSystem.Mouse mouse = UnityEngine.InputSystem.Mouse.current;

            if (mouse == null)
            {
                return;
            }

            Vector2 mousePosition = mouse.position.ReadValue();

            bool positionHasChanged = mousePosition != lastMousePosition;

            if(!positionHasChanged)
            {
                return;
            }


            lastMousePosition = mousePosition;

            SetMouseVisible(true);

            timer.Restart();
        }

        private void TryHideMouse()
        {
            if(!Cursor.visible)
            {
                return;
            }

            if(!timer.HasReached(TimeSpan.FromSeconds(hideAfterTime)))
            {
                return;
            }

            SetMouseVisible(false);
        }
    }
}
