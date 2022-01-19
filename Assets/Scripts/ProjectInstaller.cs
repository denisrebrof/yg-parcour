using Gameplay.Inputs;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private FirstPersonLook look;

    public override void InstallBindings()
    {
        Container.BindInstance(look).AsSingle();
        var handler = new InputHandler();
        Container.BindInterfacesAndSelfTo<InputHandler>().FromInstance(handler).AsSingle();
        Container.Bind<FirstPersonLook.ILookDeltaProvider>().To<FirstPersonLookDeltaProviderRouter>().AsSingle();
        Container.Bind<FirstPersonMovement.IMovementInputProvider>().To<MovementInputProviderRouter>().AsSingle();
        Container.Bind<Jump.IJumpInputProvider>().To<JumpInputProviderRouter>().AsSingle();
    }
}