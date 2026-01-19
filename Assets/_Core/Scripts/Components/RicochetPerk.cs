using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class RicochetPerk : MonoBehaviour, IAbilityTarget, IConvertGameObjectToEntity
{
    public List<GameObject> Targets { get; set; }
    private Entity entity;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        this.entity = entity;
    }

    public void Execute()
    {
        GameState.RicochetEnabled = true;
        Destroy(gameObject);
        World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(entity);
    }
}
