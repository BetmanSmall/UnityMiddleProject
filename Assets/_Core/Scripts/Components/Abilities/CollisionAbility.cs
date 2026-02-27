using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CollisionAbility : MonoBehaviour, IConvertGameObjectToEntity, IAbility
{
    public Collider Collider;

    public List<MonoBehaviour> collisionActions = new List<MonoBehaviour>();
    public List<IAbility> abilities = new List<IAbility>();

    [HideInInspector] public List<Collider> collisions;

    void Awake()
    {
        if (Collider == null) Collider = gameObject.GetComponent<Collider>();
    }

    void Start()
    {
        foreach (var action in collisionActions)
        {
            if (action is IAbility ability)
            {
                abilities.Add(ability);
            }
            else
            {
                Debug.LogError("CollisionAbility::Start(); -- Collision action is not an ability");
            }
        }
    }

    public void Execute()
    {
        // Debug.Log("CollisionAbility::Execute(); -- ");
        foreach (var ability in abilities)
        {
            if (ability is IAbilityTarget abilityTarget)
            {
                abilityTarget.Targets = new List<GameObject>();
                collisions.ForEach(c =>
                {
                    if (c != null) abilityTarget.Targets.Add(c.gameObject);
                });
            }
            ability.Execute();
        }
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        float3 position = gameObject.transform.position;
        switch (Collider)
        {
            case SphereCollider sphere:
            {
                sphere.ToWorldSpaceSphere(out var sphereCenter, out var sphereRadius);
                dstManager.AddComponentData(entity, new ActorColliderData
                {
                    ColliderType = ColliderType.Sphere,
                    SphereCenter = sphereCenter - position,
                    SphereRadius = sphereRadius,
                    initialTakeoff = true
                });
                break;
            }
            case CapsuleCollider capsule:
            {
                capsule.ToWorldSpaceCapsule(point0: out var capsuleStart, point1: out var capsuleEnd, out var capsuleRadius);
                dstManager.AddComponentData(entity, new ActorColliderData
                {
                    ColliderType = ColliderType.Capsule,
                    CapsuleStart = capsuleStart - position,
                    CapsuleEnd = capsuleEnd - position,
                    CapsuleRadius = capsuleRadius,
                    initialTakeoff = true
                });
                break;
            }
            case BoxCollider box:
            {
                box.ToWorldSpaceBox(out var boxCenter, out var boxHalfExtents, out var boxOrientation);
                dstManager.AddComponentData(entity, new ActorColliderData
                {
                    ColliderType = ColliderType.Box,
                    BoxCenter = boxCenter - position,
                    BoxHalfExtents = boxHalfExtents,
                    BoxOrientation = boxOrientation,
                    initialTakeoff = true
                });
                break;
            }
        }
        Collider.enabled = false;
    }
}

public struct ActorColliderData : IComponentData
{
    public ColliderType ColliderType;
    public float3 SphereCenter;
    public float SphereRadius;
    public float3 CapsuleStart;
    public float3 CapsuleEnd;
    public float CapsuleRadius;
    public float3 BoxCenter;
    public float3 BoxHalfExtents;
    public quaternion BoxOrientation;
    public bool initialTakeoff;
}

// 4 usages 4 exposing APIs
public enum ColliderType
{
    Sphere = 0,
    Capsule = 1,
    Box = 2
}
