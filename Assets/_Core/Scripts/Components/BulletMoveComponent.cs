using UnityEngine;
using Unity.Entities;

public class BulletMoveComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    public float moveSpeed = 1f;
    public float lifetime = 5f;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BulletVelocityComponent
        {
            Velocity = transform.forward * moveSpeed
        });
        dstManager.AddComponentData(entity, new LifetimeComponent
        {
            LifeTime = lifetime,
            SpawnTime = Time.time
        });
        if (GameState.RicochetEnabled)
        {
            dstManager.AddComponentData(entity, new RicochetBulletComponent());
            BulletCollisionHandler bulletCollisionHandler = gameObject.GetComponent<BulletCollisionHandler>();
            if (bulletCollisionHandler != null)
            {
                bulletCollisionHandler.destroyOnCollision = false;
            }
        }
    }
}
