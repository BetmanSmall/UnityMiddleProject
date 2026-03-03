using UnityEngine;
using Unity.Entities;
using Zenject;

public class BulletMoveComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    [Inject] private IGameConfigProvider _configProvider;
    public float moveSpeed = 1f;
    public float lifetime = 5f;

    void Start()
    {
        moveSpeed = _configProvider.BulletSpeed;
    }

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
            dstManager.AddComponentData(entity, new RicochetBulletDataComponent
            {
                CurrentBounces = 0,
                MaxBounces = _configProvider.RicochetMaxBounces
            });
            BulletCollisionHandler bulletCollisionHandler = gameObject.GetComponent<BulletCollisionHandler>();
            if (bulletCollisionHandler != null)
            {
                bulletCollisionHandler.destroyOnCollision = false;
            }
        }
    }
}
