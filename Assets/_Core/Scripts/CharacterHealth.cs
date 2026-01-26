using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public Settings settings;
    public ShootAbility shootAbility;
    private int _health = 1000;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            if (_health <= 0) {
                WriteStatistics();
                gameObject.SetActive(false);
            }
        }
    }

    private void WriteStatistics()
    {
        var jsonStatistics = JsonUtility.ToJson(shootAbility.playerStats);
        Debug.Log(jsonStatistics);
        PlayerPrefs.SetString("statistics", jsonStatistics);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        _health = settings.MaxHealth;
    }
}
