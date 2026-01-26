using System;
using UnityEngine;

public class ShootAbility : MonoBehaviour, IAbility
{
    public GameObject bullet;
    public float shootDelay = 2f;
    public Vector3 shootOffset = Vector3.up;

    private float _shootTime = float.MinValue; 
    public PlayerStats playerStats;

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
        } else
        {
            Debug.LogError("No bullet to shoot");
        }
    }
}
