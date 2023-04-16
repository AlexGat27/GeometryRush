using UnityEngine;
using System;
using LevelCore.Environment;

namespace Player
{
    [RequireComponent(typeof(CollisionsDetector))]
    public sealed class HealthSystem : MonoBehaviour
    {
        private CollisionsDetector _collisionDetector;

        public event Action OnDead;

        private void Awake()
        {
            _collisionDetector = GetComponent<CollisionsDetector>();
        }

        private void OnEnable()
        {
            _collisionDetector.OnFacedWithObstacle += PlayDeath;
        }

        private void OnDisable()
        {
            _collisionDetector.OnFacedWithObstacle -= PlayDeath;
        }

        private void PlayDeath(ILevelObject levelObject)
        {
            OnDead?.Invoke();
        }
    }
}