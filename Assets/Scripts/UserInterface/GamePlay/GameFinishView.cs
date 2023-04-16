using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelCore.Environment;
using UnityEngine.SceneManagement;

namespace UserInterface.GamePlay
{
    internal sealed class GameFinishView : MonoBehaviour, IView
    {
        [SerializeField] private GameObject _view;
        [SerializeField] private FinishPoint _finishPoint;

        private bool _hasGameFinished;

        private void Awake()
        {
            _finishPoint.OnLevelCompleted += delegate { Open(); _hasGameFinished = true; };
        }
        public void Close()
        {
            _view.SetActive(false);
        }
        public void Open()
        {
            _view.SetActive(true);
        }

        public void GotoMenu()
        {
            if (!_hasGameFinished)
                return;

            SceneManager.LoadScene(0);
        }
    }
}