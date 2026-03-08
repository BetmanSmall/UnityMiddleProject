public interface ILevelUp
{
    public void LevelUp(CharacterLevel characterLevel, int level);

    public int MinLevel { get; }
}