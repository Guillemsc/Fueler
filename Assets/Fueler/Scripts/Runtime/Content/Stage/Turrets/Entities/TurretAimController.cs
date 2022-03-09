using System;
using UnityEngine;

namespace Fueler.Content.Stage.Turrets.Entities
{
    public class TurretAimController : MonoBehaviour
    {
        private const float MinDistanceEpsilon = 0.001f;

        [Header("References")]
        [SerializeField] private Transform aimPivot = default;

        [Header("Values")]
        [SerializeField, Range(-180, 180)] float angleOffset = default;
        [SerializeField, Min(0)] private float aimAcceleration = 100f;
        [SerializeField, Min(0)] private float aimMaxVelocity = 100f;

        private float currentAimSpeed;
        private float targetAimAngle;

        public float TargetAngleDifference { get; private set; }
        public Transform Target { get; set; }

        private void Update()
        {
            CalculateTargetAimAngle();

            MoveTowardsTargetAimAngle();
        }

        private float GetAimAngleDifference()
        {
            float currentAimAngle = aimPivot.rotation.eulerAngles.z + angleOffset;

            return Mathf.DeltaAngle(currentAimAngle, targetAimAngle);
        }

        private float GetDistanceToDecelerate()
        {
            float pow = Mathf.Pow(currentAimSpeed, 2);

            return (-pow) / (2f * aimAcceleration);
        }

        private void MoveTowardsTargetAimAngle()
        {
            TargetAngleDifference = GetAimAngleDifference();

            if (Mathf.Abs(TargetAngleDifference) < MinDistanceEpsilon)
            {
                return;
            }

            float direction = 1f;

            if(TargetAngleDifference < 0)
            {
                direction = -1f;
            }

            float distanceToDecelerate = GetDistanceToDecelerate();

            bool underAimDecelerationAngle = Math.Abs(TargetAngleDifference) <= Math.Abs(distanceToDecelerate);

            if (underAimDecelerationAngle)
            {
                direction = -direction;
            }

            currentAimSpeed += aimAcceleration * Time.deltaTime * direction;

            currentAimSpeed = Mathf.Clamp(currentAimSpeed, -aimMaxVelocity, aimMaxVelocity);

            float currentAimSpeedDelta = currentAimSpeed * Time.deltaTime;

            bool speedIsBiggerThanDistance = Math.Abs(TargetAngleDifference) <= Math.Abs(currentAimSpeedDelta);

            if(speedIsBiggerThanDistance)
            {
                currentAimSpeedDelta = -TargetAngleDifference;
                currentAimSpeed = 0;
            }

            aimPivot.transform.rotation *= Quaternion.Euler(0, 0, currentAimSpeedDelta);
        }

        private void CalculateTargetAimAngle()
        {
            if(Target == null)
            {
                return;
            }

            Vector2 p1 = transform.position;    
            Vector2 p2 = Target.position;

            float xDiff = p2.x - p1.x;
            float yDiff = p2.y - p1.y;

            targetAimAngle = Mathf.Atan2(yDiff, xDiff) * Mathf.Rad2Deg;
        }
    }
}
