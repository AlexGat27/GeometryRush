using UnityEngine;

namespace UserInterface.MainMenu.Levels
{
    internal sealed class LevelsContainerView : MonoBehaviour, IView
    {
        [SerializeField] private Transform _cellsGrid;
        [SerializeField] private LevelInfoCell _levelCellPrefab;
        private LevelSelector _levelSelector;

        private void Awake()
        {
            _levelSelector = FindObjectOfType<LevelSelector>();

            _levelSelector.OnLevelsHaveLoaded += LoadLevelCells;
        }

        public void Close()
        {

        }

        public void Open()
        {

        }

        private void LoadLevelCells(ILevelInfo[] levelsInfo)
        {
            foreach (var levelInfo in levelsInfo)
            {
                LevelInfoCell cell = Instantiate(_levelCellPrefab, _cellsGrid);
                cell.Initialize(levelInfo);
                cell.StartButton.onClick.AddListener(
                    delegate { _levelSelector.StartLevel(levelInfo); });
            }
        }
    }
}