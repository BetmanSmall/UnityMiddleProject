using System;

[Serializable]
public class GameConfig
{
    public float playerSpeed = 5f;
    public int maxHealth = 100;
    public float shootCooldown = 0.5f;
    public int bulletDamage = 10;
    public float dashDistance = 3f;
    public float dashCooldown = 1f;
    public string gameTitle = "Unity Middle Project";
    public bool enableSound = true;
    public float musicVolume = 0.8f;
    public float sfxVolume = 1.0f;
    public int maxZombies = 10;
    public float zombieSpawnRate = 2f;
    public float zombieSpeed = 2f;
    public int zombieDamage = 20;
    public float medpackHealAmount = 30f;
    public float trapDamage = 50f;
    public float bulletSpeed = 10f;
    public int ricochetMaxBounces = 3;
    public float gravity = -9.81f;
    public float jumpForce = 5f;
    
    // Дополнительные параметры конфигурации можно добавить здесь
}