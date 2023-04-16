using UnityEngine;

namespace UserInterface.MainMenu.Levels
{
    public interface ILevelInfo
    {
        public string Name { get; }
        public Sprite Icon { get; }
        public string Description { get; }
        public int SceneIndex { get; }
        public float ProgressPercentage { get; set; }
    }
}