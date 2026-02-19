using UnityEngine;
using Unity.Entities;

public class BulletMoveSystem : ComponentSystem
{
    private EntityQuery _bulletMoveQuery;

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
