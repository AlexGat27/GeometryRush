using UnityEngine;

namespace Player
{
    internal sealed class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _bottomBound = 9.99f;
        [SerializeField] private float _topBound = 12.62f;
        [SerializeField] private float _leftBound;
        [SerializeField] private float _rightBound;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }

        private void Update()
        {
            Vector2 playerPosition = _playerMovement.transform.position;
            float xPosition = Mathf.Clamp(playerPosition.x, _leftBound, _rightBound);

            float yPosition = Mathf.Clamp(playerPosition.y, _bottomBound, _topBound);
            transform.position = new Vector3(xPosition, yPosition, -10);
        }
    }
}