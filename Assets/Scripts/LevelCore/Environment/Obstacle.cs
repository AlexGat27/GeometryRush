using UnityEngine;

namespace LevelCore.Environment
{
    public sealed class Obstacle : MonoBehaviour, ILevelObject
    {
        public LevelObjectType Type { get { return LevelObjectType.Obstacle; } }
    }
}