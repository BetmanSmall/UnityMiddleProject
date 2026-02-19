using Unity.Entities;
using UnityEngine;

public class LifeTimeSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAllReadOnly<LifetimeComponent>().ForEach((Entity entity) =>
        {
            var bulletLifetime = EntityManager.GetComponentData<LifetimeComponent>(entity);
            if (World.Time.ElapsedTime > bulletLifetime.SpawnTime + bulletLifetime.LifeTime)
            {
                var transform = EntityManager.GetComponentObject<Transform>(entity);
                if (transform == null) {
                    EntityManager.DestroyEntity(entity);
                    return;
                }
                Object.Destroy(transform.gameObject);
                EntityManager.DestroyEntity(entity);
            }
        });
    }
}
