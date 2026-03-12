using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CharacterHealth : MonoBehaviour
{
    [Inject] private IGameConfigProvider _configProvider;

    public ShootAbility shootAbility;
    public int _health;
    private AnimationTriggerComponent _animationTrigger;

    public UnityEvent OnDeath;

    private ViewModelCanvas _viewModelCanvas;

    public int Health
    {
        get => _health;
        set
        {
            if (_health == value) return;
            // Debug.Log("CharacterHealth::Health(); -- previous value: " + _health);
            // Debug.Log("CharacterHealth::Health(); -- new value: " + value);
            if (_health < 0) return;
            int previousHealth = _health;
            _health = value;
            if (_viewModelCanvas != null)
            {
                _viewModelCanvas.Health = _health.ToString();
            }
            if (_health < previousHealth && _animationTrigger != null)
            {
                _animationTrigger.TriggerTakeDamage();
            }
            if (_health <= 0) {
                if (_animationTrigger != null)
                {
                    _animationTrigger.TriggerDeath();
                }
                WriteStatistics();
                OnDeath.Invoke();
                Invoke(nameof(DeactivateAfterDeath), 10f);
            }
        }
    }

    private void Start()
    {
        _viewModelCanvas = FindObjectOfType<ViewModelCanvas>();
        Health = _configProvider.MaxHealth;
        _animationTrigger = GetComponent<AnimationTriggerComponent>();
    }

    private void WriteStatistics()
    {
        if (shootAbility == null) return;
        var jsonStatistics = JsonUtility.ToJson(shootAbility.playerStats);
        Debug.Log(jsonStatistics);
        PlayerPrefs.SetString("statistics", jsonStatistics);
        PlayerPrefs.Save();
    }

    private void DeactivateAfterDeath()
    {
        gameObject.SetActive(false);
    }
}
