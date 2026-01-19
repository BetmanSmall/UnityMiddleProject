using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TrapAbility : CollisionAbility, ICollisionAbility
{
    public int Damage;

    public void Execute()
    {
        foreach (var targer in Collisions)
        {
            var targetHealth = targer?.GetComponent<CharacterHealth>();
            if (targetHealth != null)
            {
                targetHealth.Health -= Damage;
            }
        }
    }
}