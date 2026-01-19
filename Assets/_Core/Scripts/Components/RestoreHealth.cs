
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class RestoreHealth : MonoBehaviour, IAbilityTarget, IConvertGameObjectToEntity
{
    public int Health = 20;
    public List<GameObject> Targets { get; set; }
    private Entity entity;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        this.entity = entity;
    }

    public void Execute()
    {
        Debug.Log("RestoreHealth::Execute(); -- Targets.Count: " + Targets.Count);
        foreach (var target in Targets)
        {
            Debug.Log("RestoreHealth::Execute(); -- Target: " + target);
            var targetHealth = target?.GetComponent<CharacterHealth>();
            Debug.Log("RestoreHealth::Execute(); -- targetHealth: " + targetHealth);
            if (targetHealth != null)
            {
                targetHealth.Health += Health;
            }
        }
        Destroy(gameObject);
        World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(entity);
    }
}
