using UnityEngine;
using Zenject;

public class AsyncConfigInstaller : MonoInstaller
{
    private ConfigService configService;
    public override void InstallBindings()
    {
        Debug.Log("AsyncConfigInstaller::InstallBindings(); -- Start");
        Container.BindInterfacesAndSelfTo<ConfigService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<GameConfig>().FromResolveGetter<ConfigService>(service => service.Config).AsTransient();
        Debug.Log("AsyncConfigInstaller::InstallBindings(); -- End");
    }

    // public override async void Start()
    // {
    //     base.Start();
    //     Debug.Log("AsyncConfigInstaller::Start(); -- Start");
    //     configService = Container.InstantiateComponent<ConfigService>(new GameObject("ConfigService"));
    //     await configService.LoadConfigAsync();
    //     Debug.Log("AsyncConfigInstaller::Start(); -- End");
    // }
}