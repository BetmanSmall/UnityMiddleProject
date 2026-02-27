using Unity.Entities;
using UnityEngine;

public struct AnimationStateComponent : IComponentData
{
    public bool IsAttacking;
    public bool IsTakingDamage;
    public bool IsDead;
    public bool HasAnimationTrigger;
    public Entity AnimationEntity;
}

public class AnimationStateAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new AnimationStateComponent
        {
            IsAttacking = false,
            IsTakingDamage = false,
            IsDead = false,
            HasAnimationTrigger = GetComponent<AnimationTriggerComponent>() != null,
            AnimationEntity = Entity.Null
        });
    }
}
