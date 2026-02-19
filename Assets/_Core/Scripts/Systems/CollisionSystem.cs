using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CollisionSystem : ComponentSystem
{
    private EntityQuery _collisionQuery;
    private Collider [] _results = new Collider[50];

    protected override void OnCreate()
    {
        _collisionQuery = GetEntityQuery(
            ComponentType.ReadOnly<ActorColliderData>(),
            ComponentType.ReadOnly<Transform>());
    }

    protected override void OnUpdate()
    {
        var dstManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        Entities.With(_collisionQuery).ForEach(
            (Entity entity, CollisionAbility collisionAbility, ref ActorColliderData colliderData) =>
        {
            var gameObject = collisionAbility.gameObject;
            if (gameObject == null)
            {
                return;
            }

            float3 position = gameObject.transform.position;
            Quaternion rotation = gameObject.transform.rotation;

            collisionAbility?.collisions?.Clear();

            int size = 0;

            switch (colliderData.ColliderType)
            {
                case ColliderType.Sphere:
                    size = Physics.OverlapSphereNonAlloc(position: colliderData.SphereCenter + position,
                        colliderData.SphereRadius, _results);
                    break;
                case ColliderType.Capsule:
                    var center = ((colliderData.CapsuleStart + position) + (colliderData.CapsuleEnd + position)) / 2f;
                    var point1 = colliderData.CapsuleStart + position;
                    var point2 = colliderData.CapsuleEnd + position;
                    point1 = (float3)(rotation * (point1 - center)) + center;
                    point2 = (float3)(rotation * (point2 - center)) + center;
                    size = Physics.OverlapCapsuleNonAlloc(point0: point1,
                        point1: point2,
                        colliderData.CapsuleRadius, _results);
                    break;
                case ColliderType.Box:
                    size = Physics.OverlapBoxNonAlloc(center: colliderData.BoxCenter + position,
                        colliderData.BoxHalfExtents, _results, orientation: colliderData.BoxOrientation * rotation);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (size > 0)
            {
                foreach (var result in _results) {
                    collisionAbility?.collisions?.Add(result);
                }
                collisionAbility.Execute();
            }
        });
    }
}
