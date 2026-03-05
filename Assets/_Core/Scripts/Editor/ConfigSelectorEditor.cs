using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

[CustomEditor(typeof(MonoBehaviour))]
public class ConfigSelectorEditor : Editor
{
    private string[] configPaths;
    private string[] configNames;
    private int selectedConfigIndex = -1;

    private void OnEnable()
    {
        RefreshConfigList();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Configuration Selection", EditorStyles.boldLabel);
        if (configNames.Length > 0)
        {
            int oldSelectedIndex = selectedConfigIndex;
            selectedConfigIndex = EditorGUILayout.Popup("Select Config", selectedConfigIndex, configNames);
            if (selectedConfigIndex != oldSelectedIndex && selectedConfigIndex >= 0)
            {
                // Сохраняем выбранный конфиг в PlayerPrefs или в ScriptableObject
                PlayerPrefs.SetString("SelectedConfigPath", configPaths[selectedConfigIndex]);
                PlayerPrefs.Save();
                // Перезагружаем сцену или обновляем конфиг
                UpdateConfigSelection();
            }
        }
        else
        {
            EditorGUILayout.HelpBox("No Settings assets found in project", MessageType.Info);
        }
        if (GUILayout.Button("Refresh Config List"))
        {
            RefreshConfigList();
        }
        if (GUILayout.Button("Create New Settings Asset"))
        {
            CreateNewSettingsAsset();
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void RefreshConfigList()
    {
        // Находим все ScriptableObject файлы типа Settings в проекте
        string[] guids = AssetDatabase.FindAssets("t:Settings");
        List<string> paths = new List<string>();
        List<string> names = new List<string>();
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string fileName = Path.GetFileNameWithoutExtension(path);
            paths.Add(path);
            names.Add($"{fileName} ({path})");
        }
        configPaths = paths.ToArray();
        configNames = names.ToArray();
        // Загружаем последний выбранный конфиг
        string lastSelectedPath = PlayerPrefs.GetString("SelectedConfigPath", "");
        selectedConfigIndex = System.Array.IndexOf(configPaths, lastSelectedPath);
        if (selectedConfigIndex == -1 && configPaths.Length > 0)
        {
            selectedConfigIndex = 0;
        }
    }

    private void UpdateConfigSelection()
    {
        if (selectedConfigIndex >= 0 && selectedConfigIndex < configPaths.Length)
        {
            string selectedPath = configPaths[selectedConfigIndex];
            Settings selectedConfig = AssetDatabase.LoadAssetAtPath<Settings>(selectedPath);
            if (selectedConfig != null)
            {
                Debug.Log($"Selected config: {selectedConfig.name} at {selectedPath}");
                // Здесь можно добавить логику обновления текущего конфига
                // Например, обновить ScriptableObjectGameConfigProvider
            }
        }
    }

    private void CreateNewSettingsAsset()
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
            RefreshConfigList();
            // Автоматически выбираем новый конфиг
            string relativePath = "Assets" + path.Substring(Application.dataPath.Length);
            selectedConfigIndex = System.Array.IndexOf(configPaths, relativePath);
        }
    }
}
