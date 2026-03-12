using System.Collections.Generic;
using UnityEngine;

public class HeartItemAbility : MonoBehaviour, IAbilityTarget, ICraftable
{
    private List<GameObject> _targets = new List<GameObject>();
    public string _name = "Heart";

    public List<GameObject> Targets
    {
        get => _targets;
        set => _targets = value;
    }

    public string Name => _name;

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
