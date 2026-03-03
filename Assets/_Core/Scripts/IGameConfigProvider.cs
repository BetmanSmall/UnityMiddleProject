public interface IGameConfigProvider
{
    int MaxHealth { get; }
    float PlayerSpeed { get; }
    float ShootCooldown { get; }
    int BulletDamage { get; }
    float DashDistance { get; }
    float DashCooldown { get; }
    float ZombieSpeed { get; }
    int ZombieDamage { get; }
    int MaxZombies { get; }
    float ZombieSpawnRate { get; }
    float MedpackHealAmount { get; }
    float TrapDamage { get; }
    float BulletSpeed { get; }
    int RicochetMaxBounces { get; }
}
