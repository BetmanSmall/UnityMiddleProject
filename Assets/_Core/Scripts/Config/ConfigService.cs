using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class ConfigService : MonoBehaviour
{
    public GameConfig Config { get; private set; }
    public bool IsLoaded { get; private set; } = false;
    public event Action OnConfigLoaded;
    public event Action<string> OnConfigLoadFailed;

    private const string CONFIG_FILE_PATH = "config.json";

    public async void Start()
    {
        Debug.Log("ConfigService::Start(); -- Start");
        await LoadConfigAsync();
        Debug.Log("ConfigService::Start(); -- End");
    }

    public async Task<GameConfig> LoadConfigAsync()
    {
        Debug.Log("ConfigService::LoadConfigAsync(); -- Start");
        try
        {
            string configPath = Path.Combine(Application.streamingAssetsPath, CONFIG_FILE_PATH);
            if (!File.Exists(configPath))
            {
                configPath = Path.Combine(Application.dataPath, "Resources", CONFIG_FILE_PATH);
            }
            if (!File.Exists(configPath))
            {
                Debug.LogWarning($"Config file not found at {configPath}. Creating default config.");
                Config = new GameConfig();
                TextAsset textAsset = Resources.Load<TextAsset>(CONFIG_FILE_PATH.Replace(".json", ""));
                if (textAsset != null)
                {
                    Config = JsonUtility.FromJson<GameConfig>(textAsset.text);
                }
                else
                {
                    CreateDefaultConfigFile();
                }
            }
            else
            {
                string jsonString = await ReadFileAsStringAsync(configPath);
                Config = JsonUtility.FromJson<GameConfig>(jsonString);
            }
            IsLoaded = true;
            OnConfigLoaded?.Invoke();
            Debug.Log("ConfigService::LoadConfigAsync(); -- Config:" + Config);
            return Config;
        }
        catch (Exception ex)
        {
            string errorMsg = $"Failed to load config: {ex.Message}";
            Debug.LogError(errorMsg);
            OnConfigLoadFailed?.Invoke(errorMsg);
            Config = new GameConfig();
            IsLoaded = true;
            return Config;
        }
    }

    private async Task<string> ReadFileAsStringAsync(string filePath)
    {
        Debug.Log("ConfigService::ReadFileAsStringAsync(); -- filePath:" + filePath);
        if (filePath.StartsWith("http"))
        {
            using (UnityWebRequest request = UnityWebRequest.Get(filePath))
            {
                var operation = request.SendWebRequest();
                while (!operation.isDone)
                {
                    await Task.Yield();
                }
                if (request.result == UnityWebRequest.Result.Success)
                {
                    return request.downloadHandler.text;
                }
                else
                {
                    throw new Exception($"Web request failed: {request.error}");
                }
            }
        }
        else
        {
            if (filePath.Contains("://") || filePath.Contains(":///"))
            {
                using (UnityWebRequest request = UnityWebRequest.Get(filePath))
                {
                    var operation = request.SendWebRequest();
                    while (!operation.isDone)
                    {
                        await Task.Yield();
                    }
                    if (request.result == UnityWebRequest.Result.Success)
                    {
                        return request.downloadHandler.text;
                    }
                    else
                    {
                        throw new Exception($"Web request failed: {request.error}");
                    }
                }
            }
            else
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }
    }

    private void CreateDefaultConfigFile()
    {
        Config = new GameConfig();
        string resourcesPath = Path.Combine(Application.dataPath, "Resources");
        if (!Directory.Exists(resourcesPath))
        {
            Directory.CreateDirectory(resourcesPath);
        }
        string configPath = Path.Combine(resourcesPath, CONFIG_FILE_PATH);
        string json = JsonUtility.ToJson(Config, true);
        File.WriteAllText(configPath, json);
        Debug.Log($"Default config file created at: {configPath}");
    }

    public T GetConfig<T>() where T : GameConfig
    {
        if (!IsLoaded)
        {
            Debug.LogWarning("Config is not loaded yet!");
            return null;
        }
        return Config as T;
    }

    public GameConfig GetConfig()
    {
        if (!IsLoaded)
        {
            Debug.LogWarning("Config is not loaded yet!");
            return new GameConfig();
        }
        return Config;
    }
}