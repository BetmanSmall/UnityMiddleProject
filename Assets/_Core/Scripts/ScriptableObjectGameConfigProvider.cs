using UnityEngine;

public class ScriptableObjectGameConfigProvider : IGameConfigProvider
{
    private readonly Settings _settings;

    public ScriptableObjectGameConfigProvider()
    {
        _settings = Resources.Load<Settings>("Settings");
        if (_settings == null)
        {
            Debug.LogWarning("Settings not found in Resources, using default values");
        }
    }

    public int MaxHealth => _settings != null ? _settings.MaxHealth : 1000;
    public float PlayerSpeed => _settings != null ? _settings.PlayerSpeed : 5f;
    public float ShootCooldown => _settings != null ? _settings.ShootCooldown : 0.5f;
    public int BulletDamage => _settings != null ? _settings.BulletDamage : 10;
    public float DashDistance => _settings != null ? _settings.DashDistance : 3f;
    public float DashCooldown => _settings != null ? _settings.DashCooldown : 1f;
    public float ZombieSpeed => _settings != null ? _settings.ZombieSpeed : 2f;
    public int ZombieDamage => _settings != null ? _settings.ZombieDamage : 20;
    public int MaxZombies => _settings != null ? _settings.MaxZombies : 10;
    public float ZombieSpawnRate => _settings != null ? _settings.ZombieSpawnRate : 2f;
    public float MedpackHealAmount => _settings != null ? _settings.MedpackHealAmount : 30f;
    public float TrapDamage => _settings != null ? _settings.TrapDamage : 50f;
    public float BulletSpeed => _settings != null ? _settings.BulletSpeed : 10f;
    public int RicochetMaxBounces => _settings != null ? _settings.RicochetMaxBounces : 3;
}
