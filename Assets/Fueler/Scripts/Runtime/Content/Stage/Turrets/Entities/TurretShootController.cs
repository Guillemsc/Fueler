using Juce.Core.Time;
using Juce.CoreUnity;
using Juce.CoreUnity.Guizmos;
using Juce.CoreUnity.Time;
using System;
using UnityEngine;

namespace Fueler.Content.Stage.Turrets.Entities
{
    public class TurretShootController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TurretAimController turretAimController = default;
        [SerializeField] private Transform bulletsInitialPositionAndRotation = default;
        [SerializeField] private Transform bulletsParent = default;
        [SerializeField] private TurretBulletController bulletPrefab = default;

        [Header("Values")]
        [SerializeField, Min(0f)] private float minDistanceToShoot = 5f;
        [SerializeField, Range(0f, 180f)] private float minAngleDifferenceToShoot = 20f;
        [SerializeField, Range(0.2f, 10f)] private float shootCooldown = 2f;
        [SerializeField, Min(0f)] private float bulletSpeed = 5f;

        private readonly ITimer shootTimer = new ScaledUnityTimer();

        public Transform Target { get; set; }

        private void Update()
        {
            TryShoot();
        }

        private bool IsCloseEnough()
        {
            if(Target == null)
            {
                return false;
            }

            return Mathf.Abs(Vector3.Distance(transform.position, Target.transform.position)) < minDistanceToShoot;
        }

        private bool HasAngleToShoot()
        {
            return Mathf.Abs(turretAimController.TargetAngleDifference) <= minAngleDifferenceToShoot;
        }

        private bool IsOnCooldown()
        {
            return !shootTimer.HasReached(TimeSpan.FromSeconds(shootCooldown));
        }

        private void TryShoot()
        {
            if(!shootTimer.Started && !shootTimer.Paused)
            {
                shootTimer.Start();
            }

            if(Target == null)
            {
                return;
            }

            bool isCloseEnough = IsCloseEnough();

            if(!isCloseEnough)
            {
                return;
            }

            bool hasAngle = HasAngleToShoot();

            if(!hasAngle)
            {
                return;
            }

            bool onCooldown = IsOnCooldown();

            if(onCooldown)
            {
                return;
            }

            Shoot();
        }

        private void Shoot()
        {
            shootTimer.Restart();

            TurretBulletController instance = bulletPrefab.InstantiateGameObjectAndGetComponent(bulletsParent);
            instance.transform.position = bulletsInitialPositionAndRotation.transform.position;
            instance.transform.rotation = bulletsInitialPositionAndRotation.rotation;
            instance.Speed = bulletSpeed;
        }

        private void OnDrawGizmos()
        {
            GizmosUtils.DrawCircle(transform.position, Vector3.forward, minDistanceToShoot, Color.red);
        }
    }
}
