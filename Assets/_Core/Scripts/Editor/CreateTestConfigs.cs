using UnityEngine;
using UnityEditor;

public class CreateTestConfigs : MonoBehaviour
{
    [MenuItem("Tools/Create Test Configs")]
    public static void CreateConfigs()
    {
        // Создаем Development конфиг
        Settings devConfig = ScriptableObject.CreateInstance<Settings>();
        devConfig.MaxHealth = 1000;
        devConfig.PlayerSpeed = 8f;
        devConfig.BulletDamage = 15;
        devConfig.ZombieSpeed = 1f;
        devConfig.ZombieDamage = 10;
        AssetDatabase.CreateAsset(devConfig, "Assets/TestConfigs/DevelopmentSettings.asset");

        // Создаем Production конфиг
        Settings prodConfig = ScriptableObject.CreateInstance<Settings>();
        prodConfig.MaxHealth = 100;
        prodConfig.PlayerSpeed = 5f;
        prodConfig.BulletDamage = 10;
        prodConfig.ZombieSpeed = 2f;
        prodConfig.ZombieDamage = 20;
        AssetDatabase.CreateAsset(prodConfig, "Assets/TestConfigs/ProductionSettings.asset");

        // Создаем Debug конфиг
        Settings debugConfig = ScriptableObject.CreateInstance<Settings>();
        debugConfig.MaxHealth = 5000;
        debugConfig.PlayerSpeed = 15f;
        debugConfig.BulletDamage = 100;
        debugConfig.ZombieSpeed = 0.5f;
        debugConfig.ZombieDamage = 5;
        AssetDatabase.CreateAsset(debugConfig, "Assets/TestConfigs/DebugSettings.asset");

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Test configs created successfully!");
    }
}