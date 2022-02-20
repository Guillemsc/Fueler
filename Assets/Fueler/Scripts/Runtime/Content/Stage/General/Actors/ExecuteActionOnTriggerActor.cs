using Juce.CoreUnity.Physics;
using UnityEngine;

namespace Fueler.Content.Stage.General.Actors
{
    public abstract class ExecuteActionOnTriggerActor<TEntity> : MonoBehaviour where TEntity : MonoBehaviour
    {
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;

        private void OnEnable()
        {
            physicsCallbacks.OnPhysicsTriggerEnter2D += OnPhysicsTriggerEnter2D;
        }

        private void OnDisable()
        {
            physicsCallbacks.OnPhysicsTriggerEnter2D -= OnPhysicsTriggerEnter2D;
        }

        private void OnPhysicsTriggerEnter2D(PhysicsCallbacks physicsCallbacks, Collider2DData collider2DData)
        {
            TEntity foundEntity = collider2DData.Collider2D.gameObject.GetComponentInParent<TEntity>();

            if(foundEntity == null)
            {
                return;
            }

            OnTrigger(foundEntity);
        }

        protected abstract void OnTrigger(TEntity entity);
    }
}
