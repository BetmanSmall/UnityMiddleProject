using Unity.Entities;

public struct RicochetBulletDataComponent : IComponentData
{
    public int CurrentBounces;
    public int MaxBounces;
}
