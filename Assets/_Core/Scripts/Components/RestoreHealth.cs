
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Zenject;

public class RestoreHealth : MonoBehaviour, IAbilityTarget, IConvertGameObjectToEntity
{
    [Inject] private IGameConfigProvider _configProvider;
    public int Health = 20;
    public List<GameObject> Targets { get; set; }
    private Entity entity;

    void Start()
    {
        Health = (int)_configProvider.MedpackHealAmount;
    }

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
