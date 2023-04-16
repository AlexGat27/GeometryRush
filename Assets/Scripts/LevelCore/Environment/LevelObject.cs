using UnityEngine;

namespace LevelCore.Environment
{
    public sealed class LevelObject : MonoBehaviour, ILevelObject
    {
        public LevelObjectType Type { get { return LevelObjectType.Default; } }
    }
}