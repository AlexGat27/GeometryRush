using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace UserInterface.MainMenu.Levels
{
    internal sealed class LevelSelector : MonoBehaviour
    {
        private ILevelInfo[] _levels;

        public event Action<ILevelInfo[]> OnLevelsHaveLoaded;

        private void Start()
        {
            LoadLevels();
        }

        private void LoadLevels()
        {
            object[] levels = Resources.LoadAll("Levels", typeof(ILevelInfo));
            _levels = new ILevelInfo[levels.Length];

            for (int i = 0; i < levels.Length; i++)
            {
                _levels[i] = levels[i] as ILevelInfo;
            }

            OnLevelsHaveLoaded?.Invoke(_levels);
        }

        public void StartLevel(ILevelInfo levelInfo)
        {
            SceneManager.LoadScene(levelInfo.SceneIndex);
        }
    }
}