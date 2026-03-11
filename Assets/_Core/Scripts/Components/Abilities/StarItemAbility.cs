using System.Collections.Generic;
using UnityEngine;


public class StarItemAbility : MonoBehaviour, IAbilityTarget
{
    public List<GameObject> Targets { get; set; } = new List<GameObject>();

    public void Execute()
    {
        foreach (var target in Targets)
        {
            var characterHealth = target.GetComponent<CharacterHealth>();
            if (characterHealth == null) return;
            characterHealth.Health += 5;
        }
        Destroy(this.gameObject);
    }
}