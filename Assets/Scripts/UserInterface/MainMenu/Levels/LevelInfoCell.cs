using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UserInterface.MainMenu.Levels
{
    internal sealed class LevelInfoCell : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _startButton;
        [SerializeField] private Slider _progressPercentageSlider;

        private ILevelInfo _levelInfo;

        public Button StartButton { get { return _startButton; } }

        public void Initialize(ILevelInfo levelInfo)
        {
            _levelInfo = levelInfo;

            _name.text = _levelInfo.Name;
            _icon.sprite = _levelInfo.Icon;
            _progressPercentageSlider.value = _levelInfo.ProgressPercentage;
        }
    }
}