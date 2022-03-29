using Fueler.Content.Shared.Input;
using Juce.Core.Time;
using Juce.CoreUnity.Time;
using System;
using UnityEngine;

namespace Fueler.Content.Stage.Ship.Entities
{
    public class ShipController : MonoBehaviour
    {
        [SerializeField, Min(0)] private float acceleration = default;
        [SerializeField, Min(0)] private float rotationSpeed = default;
        [SerializeField, Min(0)] private float autobreakTime = 0.4f;

        private @StageInputActions stageInputActions;

        private Vector2 currentSpeed;

        private Vector2 startingAutobreakSpeed;
        private ITimer autobreakTimer = new ScaledUnityTimer();

        public bool CanInputForward { get; set; } = true;
        public bool Autobreak { get; set; }
        public bool CanMove { get; set; } = true;

        public event Action OnForwardOrBackward;

        private void Awake()
        {
            stageInputActions = new StageInputActions();
            stageInputActions.Enable();
        }

        private void Update()
        {
            UpdateAutobreak();

            UpdateInput();

            UpdatePosition();
        }
        private void UpdateInput()
        {
            if(Autobreak)
            {
                return;
            }

            InputForward();

            InputRotation();
        }

        private void InputForward()
        {
            if(!CanInputForward)
            {
                return;
            }

            if(!CanMove)
            {
                return;
            }

            Vector2 forward = new Vector2(gameObject.transform.up.x, gameObject.transform.up.y);

            float moveForwardValue = stageInputActions.Player.MoveShipForward.ReadValue<float>();

            if (moveForwardValue > 0f)
            {
                currentSpeed += forward * acceleration * UnityEngine.Time.deltaTime;

                OnForwardOrBackward?.Invoke();
            }
        }

        private void InputRotation()
        {
            if(!CanMove)
            {
                return;
            }

            float rotateLeftValue = stageInputActions.Player.RotateShipLeft.ReadValue<float>();
            float rotateRightValue = stageInputActions.Player.RotateShipRight.ReadValue<float>();

            if (rotateLeftValue > 0f)
            {
                float deltaRotationSpeed = rotationSpeed * UnityEngine.Time.deltaTime;

                gameObject.transform.localRotation *= Quaternion.Euler(
                    0,
                    0,
                    deltaRotationSpeed
                    );
            }
            else if (rotateRightValue > 0f)
            {
                float deltaRotationSpeed = rotationSpeed * UnityEngine.Time.deltaTime;

                gameObject.transform.localRotation *= Quaternion.Euler(
                    0,
                    0,
                    -deltaRotationSpeed
                    );
            }
        }

        private void UpdateAutobreak()
        {
            if(!Autobreak)
            {
                return;
            }

            if(!autobreakTimer.Started)
            {
                autobreakTimer.Start();
                startingAutobreakSpeed = startingAutobreakSpeed = currentSpeed;
            }

            float currentSeconds = (float)autobreakTimer.Time.TotalSeconds;

            if(currentSeconds > autobreakTime)
            {
                currentSpeed = Vector2.zero;
                return;
            }

            float autobreakNormalizedTime = 0f;

            if(autobreakTime > 0)
            {
                autobreakNormalizedTime = (float)autobreakTimer.Time.TotalSeconds / autobreakTime;
            }

            UnityEngine.Debug.Log(autobreakNormalizedTime);

            Vector2 newCurrentSpeed = Vector2.Lerp(startingAutobreakSpeed, Vector2.zero, autobreakNormalizedTime);

            currentSpeed = newCurrentSpeed;
        }

        private void UpdatePosition()
        {
            if(!CanMove)
            {
                return;
            }

            Vector2 deltaCurrentSpeed = currentSpeed * UnityEngine.Time.deltaTime;

            gameObject.transform.position += new Vector3(
                deltaCurrentSpeed.x,
                deltaCurrentSpeed.y,
                0
                );
        }
    }
}
