using Unity.Entities;

public class DeathAnimationSystem : ComponentSystem
{
    private EntityQuery _deathQuery;
    
    protected override void OnCreate()
    {
        _deathQuery = GetEntityQuery(
            ComponentType.ReadWrite<AnimationStateComponent>(),
            ComponentType.ReadOnly<CharacterHealth>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_deathQuery).ForEach(
            (Entity entity, CharacterHealth health, ref AnimationStateComponent animationState) =>
            {
                if (health._health <= 0 && !animationState.IsDead)
                {
                    animationState.IsDead = true;
                }
            }
        );
    }
}
