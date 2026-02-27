using Unity.Entities;

public class AttackTriggerSystem : ComponentSystem
{
    private EntityQuery _shootQuery;
    
    protected override void OnCreate()
    {
        _shootQuery = GetEntityQuery(
            ComponentType.ReadOnly<ShootData>(),
            ComponentType.ReadWrite<AttackAnimationData>());
    }

    protected override void OnUpdate()
    {
    }
}