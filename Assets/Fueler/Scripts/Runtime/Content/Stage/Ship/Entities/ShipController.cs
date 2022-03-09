using System;
using UnityEngine;

namespace Fueler.Content.Stage.Ship.Entities
{
    public class ShipController : MonoBehaviour
    {
        [SerializeField, Min(0)] private float acceleration = default;
        [SerializeField, Min(0)] private float rotationSpeed = default;

        private Vector2 currentSpeed;

        public bool CanInputForward { get; set; } = true;
        public bool Autobreak { get; set; }
        public bool CanMove { get; set; } = true;

        public event Action OnForwardOrBackward;

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

            Vector2 forward = new Vector2(gameObject.transform.up.x, gameObject.transform.up.y);

            if (Input.GetKey("w"))
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

            if (Input.GetKey("a"))
            {
                float deltaRotationSpeed = rotationSpeed * Time.deltaTime;

                gameObject.transform.localRotation *= Quaternion.Euler(
                    0,
                    0,
                    deltaRotationSpeed
                    );
            }
            else if (Input.GetKey("d"))
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

            currentSpeed -= currentSpeed.normalized * acceleration * Time.deltaTime * 3;
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
