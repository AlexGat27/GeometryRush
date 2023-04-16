using UnityEngine;
using System;
using LevelCore.Environment;

namespace Player
{
    internal sealed class SideTrigger : MonoBehaviour
    {
        [SerializeField] private Vector2 _deltaPosition;
        private PlayerMovement _playerMovement;

        public event Action<ILevelObject> OnSideTriggered;

        private void Awake()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }

        private void Update()
        {
            transform.position = (Vector2)_playerMovement.transform.position + _deltaPosition;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (contact.collider.TryGetComponent(out ILevelObject levelObject))
                {
                    OnSideTriggered?.Invoke(levelObject);
                    return;
                }
            }
        }
    }
}