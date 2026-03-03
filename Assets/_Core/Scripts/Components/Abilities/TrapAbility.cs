using UnityEngine;
using Zenject;

public class TrapAbility : CollisionAbility
{
    [Inject] private IGameConfigProvider _configProvider;
    public int Damage;

    void Start()
    {
        Damage = (int)_configProvider.TrapDamage;
    }

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
