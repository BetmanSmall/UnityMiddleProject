using UnityEngine;
using Unity.Entities;
using Zenject;

public class BulletMoveSystem : ComponentSystem
{
    private EntityQuery _bulletMoveQuery;
    [Inject] private IGameConfigProvider _configProvider;

    protected override void OnCreate()
    {
        _bulletMoveQuery = GetEntityQuery(ComponentType.ReadOnly<BulletMoveComponent>(), ComponentType.ReadOnly<BulletVelocityComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_bulletMoveQuery).ForEach((Entity entity, BulletMoveComponent bulletMoveComponent, ref BulletVelocityComponent velocity) =>
        {
            var transform = EntityManager.GetComponentObject<Transform>(entity);
            if (transform == null)
            {
                EntityManager.DestroyEntity(entity);
                return;
            }

            Vector3 moveDelta = velocity.Velocity * World.Time.DeltaTime;
            float distance = moveDelta.magnitude;
            if (EntityManager.HasComponent<RicochetBulletComponent>(entity) && Physics.Raycast(transform.position, moveDelta.normalized, out RaycastHit hit, distance))
            {
                if (EntityManager.HasComponent<RicochetBulletDataComponent>(entity))
                {
                    var ricochetData = EntityManager.GetComponentData<RicochetBulletDataComponent>(entity);
                    ricochetData.CurrentBounces++;
                    if (ricochetData.CurrentBounces >= ricochetData.MaxBounces)
                    {
                        EntityManager.DestroyEntity(entity);
                        return;
                    }
                    EntityManager.SetComponentData(entity, ricochetData);
                }
                else
                {
                    var ricochetData = new RicochetBulletDataComponent
                    {
                        CurrentBounces = 1,
                        MaxBounces = _configProvider.RicochetMaxBounces
                    };
                    EntityManager.AddComponentData(entity, ricochetData);
                }
                velocity.Velocity = Vector3.Reflect(velocity.Velocity, hit.normal);
                transform.rotation = Quaternion.LookRotation(velocity.Velocity);
                transform.position = hit.point + hit.normal * 0.01f;
            }
            else
            {
                transform.position += moveDelta;
            }
        });
    }
}
