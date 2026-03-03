using UnityEngine;

public class ConfigBasedGameConfigProvider : IGameConfigProvider
{
    private ConfigService _configService;
    private bool _isConfigServiceResolved = false;
    private readonly object _lock = new object();
    
    public ConfigBasedGameConfigProvider(ConfigService configService)
    {
        this._configService = configService;
        this._isConfigServiceResolved = true;
    }
    
    private ConfigService GetConfigService()
    {
        if (!_isConfigServiceResolved)
        {
            lock (_lock)
            {
                if (!_isConfigServiceResolved)
                {
                    _configService = GameObject.FindObjectOfType<ConfigService>();
                    _isConfigServiceResolved = _configService != null;
                }
            }
        }
        return _configService;
    }
    
    public int MaxHealth => GetConfigService()?.Config?.maxHealth ?? 100;
    public float PlayerSpeed => GetConfigService()?.Config?.playerSpeed ?? 5f;
    public float ShootCooldown => GetConfigService()?.Config?.shootCooldown ?? 0.5f;
    public int BulletDamage => GetConfigService()?.Config?.bulletDamage ?? 10;
    public float DashDistance => GetConfigService()?.Config?.dashDistance ?? 3f;
    public float DashCooldown => GetConfigService()?.Config?.dashCooldown ?? 1f;
    public float ZombieSpeed => GetConfigService()?.Config?.zombieSpeed ?? 2f;
    public int ZombieDamage => GetConfigService()?.Config?.zombieDamage ?? 20;
    public int MaxZombies => GetConfigService()?.Config?.maxZombies ?? 10;
    public float ZombieSpawnRate => GetConfigService()?.Config?.zombieSpawnRate ?? 2f;
    public float MedpackHealAmount => GetConfigService()?.Config?.medpackHealAmount ?? 30f;
    public float TrapDamage => GetConfigService()?.Config?.trapDamage ?? 50f;
    public float BulletSpeed => GetConfigService()?.Config?.bulletSpeed ?? 10f;
    public int RicochetMaxBounces => GetConfigService()?.Config?.ricochetMaxBounces ?? 3;
}
