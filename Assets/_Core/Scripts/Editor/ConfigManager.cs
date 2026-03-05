using UnityEngine;
using UnityEditor;
using System.IO;

public class ConfigManager : MonoBehaviour
{
    [MenuItem("Tools/Update Active Config")]
    public static void UpdateActiveConfig()
    {
        string selectedConfigPath = PlayerPrefs.GetString("SelectedConfigPath", "");
        if (!string.IsNullOrEmpty(selectedConfigPath))
        {
            Settings selectedConfig = AssetDatabase.LoadAssetAtPath<Settings>(selectedConfigPath);
            if (selectedConfig != null)
            {
                // Копируем выбранный конфиг в Resources/Settings.asset
                string resourcesPath = "Assets/Resources";
                if (!AssetDatabase.IsValidFolder(resourcesPath))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }
                string targetPath = "Assets/Resources/Settings.asset";
                // Удаляем старый файл, если существует
                if (File.Exists(Application.dataPath + "/Resources/Settings.asset"))
                {
                    AssetDatabase.DeleteAsset(targetPath);
                }
                // Копируем выбранный конфиг в Resources
                AssetDatabase.CopyAsset(selectedConfigPath, targetPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Debug.Log($"Active config updated to: {selectedConfig.name}");
                EditorUtility.DisplayDialog("Config Updated", 
                    $"Successfully updated active config to: {selectedConfig.name}", 
                    "OK");
            }
        }
        else
        {
            EditorUtility.DisplayDialog("No Config Selected", 
                "Please select a config in the MyInstaller component first.", 
                "OK");
        }
    }
    [MenuItem("Tools/Create New Config")]
    public static void CreateNewConfig()
    {
        Settings newSettings = ScriptableObject.CreateInstance<Settings>();
        string path = EditorUtility.SaveFilePanelInProject(
            "Save Settings Asset",
            "NewSettings.asset",
            "asset",
            "Choose a location to save the settings asset");
        if (!string.IsNullOrEmpty(path))
        {
            AssetDatabase.CreateAsset(newSettings, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"New config created: {path}");
        }
    }
}
