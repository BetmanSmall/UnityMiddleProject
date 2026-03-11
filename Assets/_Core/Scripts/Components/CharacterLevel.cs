using System.Collections.Generic;
using UnityEngine;

public class CharacterLevel : MonoBehaviour
{
    public List<MonoBehaviour> levelUpActions;

    public GameObject InventoryUIRoot;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int score = 0;
    [SerializeField] private int scoreToNextLevel = 20;

    private List<IItem> items;

    public int CurrentLevel => currentLevel;

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        if (score >= scoreToNextLevel) LevelUp();
    }

    private void LevelUp()
    {
        currentLevel++;
        scoreToNextLevel += 10;
        foreach (var action in levelUpActions)
        {
            if (!(action is ILevelUp levelUp)) return;
            levelUp.LevelUp(this, currentLevel);
        }
    }
}