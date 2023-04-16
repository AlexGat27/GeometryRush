using UnityEngine;
using LevelCore.Environment;
using System;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public sealed class CollisionsDetector : MonoBehaviour
    {
        [SerializeField] private SideTrigger _frontSideTrigger;
        [Header("Cube parameters")]
        [SerializeField] private float _squareWidth = 1f;
        [SerializeField] private float _quareHeigth = 1f;

        public event Action<ILevelObject> OnFacedWithObstacle;
        public event Action<bool> OnGroundedValueChanged;

        private void Awake()
        {
            _frontSideTrigger.OnSideTriggered += delegate { Debug.Log("dsadsa"); };

            _frontSideTrigger.OnSideTriggered += (levelObject) => OnFacedWithObstacle?.Invoke(levelObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (contact.collider.TryGetComponent(out ILevelObject levelObject))
                {
                    Vector2 localContactPoint = collision.GetContact(0).point - (Vector2)transform.position;

                    bool isGrounded = localContactPoint.y <= -(_quareHeigth / 2) + 0.03f;
                    OnGroundedValueChanged?.Invoke(isGrounded);

                    if (levelObject.Type == LevelObjectType.Obstacle)
                    {
                        OnFacedWithObstacle?.Invoke(levelObject);
                    }
                }
            }
        }
    }
}