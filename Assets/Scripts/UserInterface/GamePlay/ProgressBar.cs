using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UserInterface.GamePlay
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Scrollbar _scrollbar;
        [SerializeField] private Transform _finishpoint;
        [SerializeField] private Transform _player;
        [SerializeField] private float distance;

        private void Awake()
        {
            _scrollbar = GetComponent<Scrollbar>();
            _player = FindObjectOfType<PlayerMovement>().transform;
            distance = _finishpoint.position.x - _player.position.x;
        }

        private void Update()
        {
            _scrollbar.size = (distance - _finishpoint.position.x + _player.position.x) / distance;
        }
    }
}
