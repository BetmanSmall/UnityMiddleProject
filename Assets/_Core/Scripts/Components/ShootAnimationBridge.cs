using Unity.Entities;
using UnityEngine;

public class ShootAnimationBridge : MonoBehaviour, IConvertGameObjectToEntity
{
    private ShootAbility _shootAbility;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        _shootAbility = GetComponent<ShootAbility>();
        if (_shootAbility != null)
        {
            dstManager.AddComponentData(entity, new AttackAnimationData
            {
                IsAttacking = false,
                LastAttackTime = 0f
            });
        }
    }
    
    private void Update()
    {
        if (_shootAbility != null)
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var entities = Object.FindObjectsOfType<GameObjectEntity>();
            foreach (var goEntity in entities)
            {
                if (goEntity.Entity != Entity.Null && entityManager.HasComponent<AttackAnimationData>(goEntity.Entity))
                {
                    var attackData = entityManager.GetComponentData<AttackAnimationData>(goEntity.Entity);
                    break;
                }
            }
        }
    }
}