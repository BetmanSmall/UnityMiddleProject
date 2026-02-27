using Unity.Entities;

public class AttackAnimationSystem : ComponentSystem
{
    private EntityQuery _attackQuery;
    
    protected override void OnCreate()
    {
        _attackQuery = GetEntityQuery(
            ComponentType.ReadWrite<AnimationStateComponent>(),
            ComponentType.ReadWrite<AttackAnimationData>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_attackQuery).ForEach(
            (Entity entity, ref AnimationStateComponent animationState, ref AttackAnimationData attackData) =>
            {
                if (attackData.IsAttacking)
                {
                    animationState.IsAttacking = true;
                }
                else
                {
                    animationState.IsAttacking = false;
                }
                attackData.IsAttacking = false;
            }
        );
    }
}
