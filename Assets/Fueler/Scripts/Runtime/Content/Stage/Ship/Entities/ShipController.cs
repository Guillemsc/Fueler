using Fueler.Content.Shared.Input;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Fueler.Content.Stage.Ship.Entities
{
    public class ShipController : MonoBehaviour
    {
        [SerializeField, Min(0)] private float acceleration = default;
        [SerializeField, Min(0)] private float rotationSpeed = default;
        [SerializeField, Min(0)] private float autobreakStrenght = 4.0f;

        private @StageInputActions stageInputActions;

        private Vector2 currentSpeed;

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

        private void OnMoveShipForward(CallbackContext callbackContext)
        {

        }

        private void OnRotateShipLeft(CallbackContext callbackContext)
        {

        }

        private void OnRotateShipRight(CallbackContext callbackContext)
        {

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
                currentSpeed += forward * acceleration * Time.deltaTime;

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
                float deltaRotationSpeed = rotationSpeed * Time.deltaTime;

                gameObject.transform.localRotation *= Quaternion.Euler(
                    0,
                    0,
                    deltaRotationSpeed
                    );
            }
            else if (rotateRightValue > 0f)
            {
                float deltaRotationSpeed = rotationSpeed * Time.deltaTime;

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

            currentSpeed -= currentSpeed.normalized * acceleration * Time.deltaTime * autobreakStrenght;
        }

        private void UpdatePosition()
        {
            if(!CanMove)
            {
                return;
            }

            Vector2 deltaCurrentSpeed = currentSpeed * Time.deltaTime;

            gameObject.transform.position += new Vector3(
                deltaCurrentSpeed.x,
                deltaCurrentSpeed.y,
                0
                );
        }
    }
}
