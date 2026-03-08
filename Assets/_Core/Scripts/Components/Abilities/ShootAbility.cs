using System;
using UnityEngine;
using Zenject;

public class ShootAbility : MonoBehaviour, IAbility
{
    [Inject] private IGameConfigProvider _configProvider;
    [Inject] private DiContainer _container;
    public GameObject bullet;
    public float shootDelay = 2f;
    public Vector3 shootOffset = Vector3.up;

    private float _shootTime = float.MinValue; 
    public PlayerStats playerStats;
    private AnimationTriggerComponent _animationTrigger;
    private CharacterLevel _characterLevel;

    void Start()
    {
        _characterLevel = GetComponent<CharacterLevel>();
        var jsonStatistics = PlayerPrefs.GetString("statistics");
        if (jsonStatistics != null && !jsonStatistics.Equals(String.Empty, StringComparison.Ordinal))
        {
            Debug.Log("jsonStatistics: " + jsonStatistics);
            playerStats = JsonUtility.FromJson<PlayerStats>(jsonStatistics);
        } else
        {
            playerStats = new PlayerStats();
        }
        _animationTrigger = GetComponent<AnimationTriggerComponent>();
        shootDelay = _configProvider.ShootCooldown;
    }

    public void Execute()
    {
        if (Time.time < _shootTime + shootDelay) return;
        _shootTime = Time.time;
        if (bullet != null)
        {
            var t = transform;
            var newBullet = _container.InstantiatePrefab(bullet, t.position + t.TransformVector(shootOffset), t.rotation, null);
            playerStats.shotsCount++;
            _characterLevel.AddScore(10);
            if (_animationTrigger != null)
            {
                _animationTrigger.TriggerAttack();
            }
        } else
        {
            Debug.LogError("No bullet to shoot");
        }
    }
}
