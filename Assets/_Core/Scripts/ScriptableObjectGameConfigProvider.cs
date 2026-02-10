using UnityEngine;

public class ScriptableObjectGameConfigProvider : IGameConfigProvider
{
    private readonly Settings _settings;

    public ScriptableObjectGameConfigProvider()
    {
        _settings = Resources.Load<Settings>("Settings");
        if (_settings == null)
        {
            Debug.LogWarning("Settings not found in Resources, using default values");
        }
    }

    public int MaxHealth => _settings != null ? _settings.MaxHealth : 1000;
}
