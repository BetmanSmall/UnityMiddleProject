using UnityEngine;
using Unity.Entities;

public class DogMoveSystem : ComponentSystem
{
    private EntityQuery _dogMoveQuery;

    protected override void OnCreate()
    {
        _dogMoveQuery = GetEntityQuery(ComponentType.ReadOnly<DogMoveComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_dogMoveQuery).ForEach((Entity entity, Transform transform, DogMoveComponent dogMoveComponent) =>
        {
           var p = transform.position; 
           p.y += (dogMoveComponent.moveSpeed/1000);
           transform.position = p;
        });
    }
}
