
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealth : MonoBehaviour, IAbilityTarget
{
    public int Health = 20;
    public List<GameObject> Targets { get; set; }

    public void Execute()
    {
        Debug.Log("RestoreHealth::Execute(); -- Targets.Count: " + Targets.Count);
        foreach (var target in Targets)
        {
            Debug.Log("RestoreHealth::Execute(); -- Target: " + target);
            var targetHealth = target?.GetComponent<CharacterHealth>();
            Debug.Log("RestoreHealth::Execute(); -- targetHealth: " + targetHealth);
            if (targetHealth != null)
            {
                targetHealth.Health += Health;
            }
        }
        Destroy(gameObject);
    }
}