
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour, IAbilityTarget
{
    public int Damage = 10;
    public List<GameObject> Targets { get; set; }
    [SerializeField] private float attackDelay = 0.1f;
    private float _attackTime = float.MinValue;

    public void Execute()
    {
        if (Time.time < _attackTime + attackDelay) return;
        _attackTime = Time.time;
        foreach (var target in Targets)
        {
            var targetHealth = target?.GetComponent<CharacterHealth>();
            if (targetHealth != null)
            {
                targetHealth.Health -= Damage;
            }
        }
    }
}