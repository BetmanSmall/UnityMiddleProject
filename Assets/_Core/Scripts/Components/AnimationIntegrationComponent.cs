using Unity.Entities;
using UnityEngine;

public class AnimationIntegrationComponent : MonoBehaviour, IConvertGameObjectToEntity
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
        dstManager.AddComponentData(entity, new AttackAnimationData
        {
            IsAttacking = false,
            LastAttackTime = 0f
        });
    }
}