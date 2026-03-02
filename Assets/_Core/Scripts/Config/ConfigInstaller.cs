using UnityEngine;
using Zenject;

public class ConfigInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("ConfigInstaller::InstallBindings(); -- Start");
        Container.BindInterfacesAndSelfTo<ConfigService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<GameConfig>().FromResolveGetter<ConfigService>(service => service.Config).AsTransient();
        Debug.Log("ConfigInstaller::InstallBindings(); -- End");
    }
}