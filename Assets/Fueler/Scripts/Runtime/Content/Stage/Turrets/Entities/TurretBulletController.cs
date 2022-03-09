using UnityEngine;

namespace Fueler.Content.Stage.Turrets.Entities
{
    public class TurretBulletController : MonoBehaviour
    {
        public float Speed { get; set; }

        private void Update()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            float speedDelta = Speed * Time.deltaTime;

            transform.position += -transform.up * speedDelta;
        }
    }
}
