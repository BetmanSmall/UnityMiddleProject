using UnityEngine;
using Unity.Entities;

public class BulletMoveSystem : ComponentSystem
{
    private EntityQuery _bulletMoveQuery;

    protected override void OnCreate()
    {
        _bulletMoveQuery = GetEntityQuery(ComponentType.ReadOnly<BulletMoveComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_bulletMoveQuery).ForEach((Entity entity, Transform transform, BulletMoveComponent bulletMoveComponent) =>
        {
            transform.position += transform.forward * bulletMoveComponent.moveSpeed / 1000;
        });
    }
}
