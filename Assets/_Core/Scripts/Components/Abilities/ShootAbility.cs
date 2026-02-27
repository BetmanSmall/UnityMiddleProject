using System;
using UnityEngine;

public class ShootAbility : MonoBehaviour, IAbility
{
    public GameObject bullet;
    public float shootDelay = 2f;
    public Vector3 shootOffset = Vector3.up;

    private float _shootTime = float.MinValue; 
    public PlayerStats playerStats;
    private AnimationTriggerComponent _animationTrigger;

    void Start()
    {
        var jsonStatistics = PlayerPrefs.GetString("statistics");
        if (jsonStatistics != null && !jsonStatistics.Equals(String.Empty, StringComparison.Ordinal))
        {
            Debug.Log("jsonStatistics: " + jsonStatistics);
            playerStats = JsonUtility.FromJson<PlayerStats>(jsonStatistics);
        } else
        {
            playerStats = new PlayerStats();
        }
        _animationTrigger = GetComponent<AnimationTriggerComponent>();
    }

    public void Execute()
    {
        if (Time.time < _shootTime + shootDelay) return;
        _shootTime = Time.time;
        if (bullet != null)
        {
            var t = transform;
            var newBullet = Instantiate(bullet, t.position + t.TransformVector(shootOffset), t.rotation);
            playerStats.shotsCount++;
            if (_animationTrigger != null)
            {
                _animationTrigger.TriggerAttack();
            }
        } else
        {
            Debug.LogError("No bullet to shoot");
        }
    }
}
