using Unity.Entities;
using UnityEngine;

public class AnimationTriggerSystem : ComponentSystem
{
    private EntityQuery _shootQuery;
    private EntityQuery _animationQuery;
    
    protected override void OnCreate()
    {
        _shootQuery = GetEntityQuery(
            ComponentType.ReadOnly<AttackAnimationData>(),
            ComponentType.Exclude<DontUseAnimationSystem>());
            
        _animationQuery = GetEntityQuery(
            ComponentType.ReadOnly<AnimationStateComponent>(),
            ComponentType.ReadOnly<AnimationTriggerComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_animationQuery).ForEach(
            (Entity entity, AnimationTriggerComponent animationTrigger, ref AnimationStateComponent animationState) =>
            {
            }
        );
    }
}
public struct DontUseAnimationSystem : IComponentData { }