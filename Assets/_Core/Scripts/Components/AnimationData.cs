using Unity.Entities;
using UnityEngine;

public struct AttackAnimationData : IComponentData
{
    public bool IsAttacking;
    public float LastAttackTime;
}

public class AttackAnimationDataAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new AttackAnimationData
        {
            IsAttacking = false,
            LastAttackTime = 0f
        });
    }
}
