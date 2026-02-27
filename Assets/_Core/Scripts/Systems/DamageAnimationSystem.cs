using Unity.Entities;
using UnityEngine;

public class DamageAnimationSystem : ComponentSystem
{
    private EntityQuery _damageQuery;
    
    protected override void OnCreate()
    {
        _damageQuery = GetEntityQuery(
            ComponentType.ReadWrite<AnimationStateComponent>(),
            ComponentType.ReadOnly<CharacterHealth>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_damageQuery).ForEach(
            (Entity entity, CharacterHealth health, ref AnimationStateComponent animationState) =>
            {
                if (health._health <= 0)
                {
                    animationState.IsDead = true;
                }
            }
        );
    }
}
