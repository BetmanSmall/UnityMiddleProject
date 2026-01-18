using Unity.Entities;
using UnityEngine;

public class BulletLifeTimeSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAllReadOnly<BulletLifetimeComponent>().ForEach((Entity entity) =>
        {
            var bulletLifetime = EntityManager.GetComponentData<BulletLifetimeComponent>(entity);
            if (World.Time.ElapsedTime > bulletLifetime.SpawnTime + bulletLifetime.LifeTime)
            {
                var transform = EntityManager.GetComponentObject<Transform>(entity);
                Object.Destroy(transform.gameObject);
                EntityManager.DestroyEntity(entity);
            }
        });
    }
}
