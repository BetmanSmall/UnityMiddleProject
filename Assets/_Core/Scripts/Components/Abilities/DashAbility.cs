using UnityEngine;
using Zenject;

public class DashAbility : MonoBehaviour, IAbility
{
    [Inject] private IGameConfigProvider _configProvider;
    public float dashDistance = 2f;
    public float dashDelay = 1f;

    private float _dashTime = float.MinValue;

    void Start()
    {
        dashDistance = _configProvider.DashDistance;
        dashDelay = _configProvider.DashCooldown;
    }

    public void Execute()
    {
        if (Time.time < _dashTime + dashDelay) return;
        _dashTime = Time.time;
        transform.position += transform.forward * dashDistance;
    }
}
