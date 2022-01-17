using Gameplay;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private FirstPersonLook look;
    public override void InstallBindings()
    {
        Container.BindInstance(look).AsSingle();
        Container.Bind<FirstPersonLook.ILookDeltaProvider>().To<FirstPersonLookDeltaProviderRouter>().AsSingle();
    }
}