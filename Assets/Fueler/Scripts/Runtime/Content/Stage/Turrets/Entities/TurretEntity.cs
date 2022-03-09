using Fueler.Content.Services.Ship;
using Fueler.Content.Stage.Ship.Entities;
using Juce.Core.Disposables;
using Juce.CoreUnity.Service;
using UnityEngine;

namespace Fueler.Content.Stage.Turrets.Entities
{
    public class TurretEntity : MonoBehaviour
    {
        [SerializeField] private TurretAimController turretController = default;
        [SerializeField] private TurretShootController turretShootController = default;

        private IShipService shipService;

        private void Awake()
        {
            shipService = ServiceLocator.Get<IShipService>();
        }

        private void Update()
        {
            SetShootingEnabled();
            TrySetPlayerTarget();
        }

        private void SetShootingEnabled()
        {
            turretShootController.CanShoot = turretController.Target != null;
        }

        private void TrySetPlayerTarget()
        {
            bool shipFound = shipService.ShipRepository.TryGet(out IDisposable<ShipEntity> shipEntity);

            if(!shipFound)
            {
                turretController.Target = null;
                return;
            }

            turretController.Target = shipEntity.Value.transform;
        }
    }
}
