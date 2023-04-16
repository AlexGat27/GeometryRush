using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Player;

namespace UserInterface.GamePlay
{
    internal sealed class GameEndView : MonoBehaviour, IView
    {
        [SerializeField] private GameObject _viewObject;
        [Space]
        [SerializeField] private Button _leaveGameButton;
        [SerializeField] private Button _restartButton;

        private HealthSystem _playerHealthSystem;

        private void Awake()
        {
            _playerHealthSystem = FindObjectOfType<HealthSystem>();

            _playerHealthSystem.OnDead += Open;

            _leaveGameButton.onClick.AddListener(LeaveGame);
            _restartButton.onClick.AddListener(RestartGame);
        }

        public void Close()
        {
            _viewObject.SetActive(false);
        }

        public void Open()
        {
            _viewObject.SetActive(true);
        }

        private void LeaveGame()
        {
            SceneManager.LoadScene(0);
        }
        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}