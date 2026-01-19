using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TrapAbility : CollisionAbility
{
    public int Damage;

    public void Execute()
    {
        foreach (var targer in collisions)
        {
            var targetHealth = targer?.GetComponent<CharacterHealth>();
            if (targetHealth != null)
            {
                targetHealth.Health -= Damage;
            }
        }
    }
}