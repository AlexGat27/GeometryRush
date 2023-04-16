using UnityEngine;
using System;
using Player;

namespace LevelCore.Environment
{
    public sealed class FinishPoint : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private bool _isLevelCompleted = false;

        public event Action OnLevelCompleted;

        private void Awake()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        }
        private void Update()
        {
            if (transform.position.x < _playerTransform.position.x)
                Finish();
        }

        private void Finish()
        {
            _isLevelCompleted = true;
            OnLevelCompleted?.Invoke();
        }
    }
}
