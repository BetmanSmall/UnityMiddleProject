using Unity.Entities;

public struct BulletLifetimeComponent : IComponentData
{
    public float LifeTime;
    public float SpawnTime;
}
