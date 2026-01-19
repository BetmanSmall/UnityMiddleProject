using UnityEngine;

public class DashAbility : MonoBehaviour, IAbility
{
    public float dashDistance = 2f;
    public float dashDelay = 1f;

    private float _dashTime = float.MinValue;

    public void Execute()
    {
        if (Time.time < _dashTime + dashDelay) return;
        _dashTime = Time.time;
        transform.position += transform.forward * dashDistance;
    }
}
