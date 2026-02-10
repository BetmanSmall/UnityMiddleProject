using UnityEngine;
using Zenject;

public enum ConfigProviderType
{
    ScriptableObject,
    Dummy
}

public class MyInstaller : MonoInstaller
{
    [SerializeField] private ConfigProviderType configProviderType = ConfigProviderType.ScriptableObject;

    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello from MyInstaller");
        Container.Bind<GreetMe>().AsSingle().NonLazy();
        Container.Bind<ITest>().To<Test1>().AsSingle().NonLazy();
        BindGameConfigProvider();
    }

    private void BindGameConfigProvider()
    {
        switch (configProviderType)
        {
            case ConfigProviderType.ScriptableObject: {
                Container.Bind<IGameConfigProvider>().To<ScriptableObjectGameConfigProvider>().AsSingle().NonLazy();
                break;
            }
            case ConfigProviderType.Dummy: {
                Container.Bind<IGameConfigProvider>().To<DummyGameConfigProvider>().AsSingle().NonLazy();
                break;
            }
        }
    }
}

public class GreetMe
{
    public GreetMe(string message)
    {
        Debug.Log(message);
    }
}

public class Test1 : ITest
{
    public void Echo()
    {
        Debug.Log("Test1");
    }
}

public class Test2 : ITest
{
    public void Echo()
    {
        Debug.Log("Test2");
    }
}

public interface ITest
{
    void Echo();
}