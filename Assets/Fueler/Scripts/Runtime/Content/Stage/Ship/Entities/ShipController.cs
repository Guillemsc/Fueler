using UnityEngine;

namespace Fueler.Content.Stage.Ship.Entities
{
    public class ShipController : MonoBehaviour
    {
        [SerializeField] private float acceleration = default;
        [SerializeField] private float rotationSpeed = default;

        public bool Autobreak { get; set; }
        public bool CanMove { get; set; } = true;

        private Vector2 currentSpeed;

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

            Vector2 forward = new Vector2(gameObject.transform.up.x, gameObject.transform.up.y);

            if (Input.GetKey("w"))
            {
                currentSpeed += forward * acceleration * Time.deltaTime;
            }
            else if (Input.GetKey("s"))
            {
                currentSpeed -= forward * acceleration * Time.deltaTime;
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
