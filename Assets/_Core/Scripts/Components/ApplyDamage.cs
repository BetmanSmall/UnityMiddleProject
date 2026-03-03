
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ApplyDamage : MonoBehaviour, IAbilityTarget
{
    [Inject] private IGameConfigProvider _configProvider;
    public int Damage = 10;
    public List<GameObject> Targets { get; set; }
    [SerializeField] private float attackDelay = 0.1f;
    private float _attackTime = float.MinValue;

    void Start()
    {
        SetZombieDamage();
        if (gameObject.TryGetComponent<BulletMoveComponent>(out var bulletMoveComponent))
        {
            SetBulletDamage();
        }
    }

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

    public void SetZombieDamage()
    {
        Damage = _configProvider.ZombieDamage;
    }

    public void SetBulletDamage()
    {
        Damage = _configProvider.BulletDamage;
    }
}
