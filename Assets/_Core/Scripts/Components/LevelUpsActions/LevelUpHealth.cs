using UnityEngine;

public class LevelUpHealth : MonoBehaviour, ILevelUp
{
    public int MinLevel => minLevel;
    public int minLevel = 5;
    public int levelUpHealth = 10;
    private CharacterHealth characterHealth;

    public void LevelUp(CharacterLevel characterLevel, int level)
    {
        if (characterHealth == null) characterHealth = GetComponent<CharacterHealth>();
        if (characterHealth == null) return;
        if (characterLevel.CurrentLevel < minLevel) return;
        characterHealth.Health += levelUpHealth;
    }
}