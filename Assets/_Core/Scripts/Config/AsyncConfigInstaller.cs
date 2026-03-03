using UnityEngine;
using Zenject;

public class AsyncConfigInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("AsyncConfigInstaller::InstallBindings(); -- Start");
        
        // Регистрируем ConfigService
        Container.BindInterfacesAndSelfTo<ConfigService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        
        // Регистрируем GameConfig как_transient
        Container.Bind<GameConfig>().FromResolveGetter<ConfigService>(service => service.Config).AsTransient();
        
        // Регистрируем IGameConfigProvider к реализации ConfigBasedGameConfigProvider
        Container.Bind<IGameConfigProvider>().To<ConfigBasedGameConfigProvider>().AsSingle();
        
        Debug.Log("AsyncConfigInstaller::InstallBindings(); -- End");
    }

    // public async override void Start()
    // {
    //     base.Start();
    //     Debug.Log("AsyncConfigInstaller::Start(); -- Start");
    //     ConfigService configService = Container.Resolve<ConfigService>();
    //     await configService.LoadConfigAsync();
    //     Debug.Log("AsyncConfigInstaller::Start(); -- End");
    // }
}
