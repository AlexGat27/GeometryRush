using UnityEngine;

namespace UserInterface.MainMenu.Levels
{
    /// <summary>
    /// Contains the information about the Level.
    /// </summary>
    [CreateAssetMenu(menuName = "DefaultLevelInfo")]
    public sealed class DefaultLevelInfo: ScriptableObject, ILevelInfo
    {
        [SerializeField] private string _name;
        [SerializeField] private int _sceneIndex;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _description;

        public DefaultLevelInfo(string name, int sceneIndex, Sprite icon,
                                string description)
        {
            _name = name;
            _sceneIndex = sceneIndex;
            _icon = icon;
            _description = description;
        }

        public string Name { get => _name; }
        public int SceneIndex { get => _sceneIndex; }
        public Sprite Icon { get => _icon; }
        public string Description { get => _description; }
        public float ProgressPercentage { get; set; }
    }
}