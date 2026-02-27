using UnityEngine;

public class TrapAbility : CollisionAbility
{
    public int Damage;

    public new void Execute()
    {
        // Debug.Log("TrapAbility::Execute(); -- collisions.Count: " + collisions.Count, gameObject);
        foreach (var target in collisions)
        {
            // Debug.Log("TrapAbility::Execute(); -- target: " + target, target.gameObject);
            var targetHealth = target?.GetComponent<CharacterHealth>();
            if (targetHealth != null)
            {
                targetHealth.Health -= Damage;
            }
        }
    }
}