public class DummyGameConfigProvider : IGameConfigProvider
{
    public int MaxHealth => 500;
    public float PlayerSpeed => 5f;
    public float ShootCooldown => 0.5f;
    public int BulletDamage => 10;
    public float DashDistance => 3f;
    public float DashCooldown => 1f;
    public float ZombieSpeed => 2f;
    public int ZombieDamage => 20;
    public int MaxZombies => 10;
    public float ZombieSpawnRate => 2f;
    public float MedpackHealAmount => 30f;
    public float TrapDamage => 50f;
    public float BulletSpeed => 10f;
    public int RicochetMaxBounces => 3;
}
