namespace LevelCore.Environment
{
    public interface ILevelObject
    {
        public LevelObjectType Type { get; }
    }

    public enum LevelObjectType
    {
        Default,
        Obstacle
    }
}
