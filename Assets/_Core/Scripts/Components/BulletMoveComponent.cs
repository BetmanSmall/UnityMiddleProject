using UnityEngine;
using Unity.Entities;

public class BulletMoveComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    public float moveSpeed = 1f;
    public float lifetime = 5f;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BulletLifetimeComponent
        {
            LifeTime = lifetime,
            SpawnTime = Time.time
        });
    }
}
