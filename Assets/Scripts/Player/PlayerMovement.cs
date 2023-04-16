using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CollisionsDetector))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _rotateCurve;

        [Header("Vertical Movement")]
        [SerializeField] private float _jumpDuration = 0.5f;
        [SerializeField] private float _jumpHeight = 1.0f;
        [SerializeField] private float _targetRotateAngle = 90f;

        [Header("Horizontal movement")]
        [SerializeField] private float _moveSpeed = 7f;

        private Rigidbody2D _rigidbody;
        private CollisionsDetector _collisionsDetector;

        private bool _isGrounded = true;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collisionsDetector = GetComponent<CollisionsDetector>();
        }

        private void Update()
        {
            if (_rigidbody.bodyType == RigidbodyType2D.Dynamic) _rigidbody.velocity = new Vector2(_moveSpeed, _rigidbody.velocity.y);
        }

        private void OnEnable()
        {
            _collisionsDetector.OnGroundedValueChanged += ChangeGroundedState;
            _collisionsDetector.OnFacedWithObstacle += delegate { MakeObjectStatic(); };
        }

        private void OnDisable()
        {
            _collisionsDetector.OnGroundedValueChanged -= ChangeGroundedState;
            _collisionsDetector.OnFacedWithObstacle -= delegate { MakeObjectStatic(); };
        }

        public void Jump()
        {
            if (!_isGrounded)
                return;

            _rigidbody.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
            StartCoroutine(Rotating());
        }

        private IEnumerator Rotating()
        {
            float expiredSeconds = 0;
            float progress = 0;
            Vector3 startPosition = transform.position;
            Quaternion startRotate = transform.rotation;
            _isGrounded = false;
            while (progress < 1)
            {
                expiredSeconds += Time.deltaTime;
                progress = expiredSeconds / _jumpDuration;
                transform.rotation = Quaternion.Euler(0, 0,
                    startRotate.z - _rotateCurve.Evaluate(progress) * _targetRotateAngle);
                yield return null;
            }
        }

        private void ChangeGroundedState(bool value)
        {
            _isGrounded = value;
        }

        private void MakeObjectStatic()
        {
            _rigidbody.bodyType = RigidbodyType2D.Static;
        }
    }
}