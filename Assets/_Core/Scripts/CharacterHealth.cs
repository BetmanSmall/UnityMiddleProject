using UnityEngine;
using Zenject;

public class CharacterHealth : MonoBehaviour
{
    [Inject] private IGameConfigProvider _configProvider;

    public ShootAbility shootAbility;
    public int _health;

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
        _health = _configProvider.MaxHealth;
    }
}
