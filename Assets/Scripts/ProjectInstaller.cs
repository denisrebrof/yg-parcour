using Gameplay.Inputs;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private FirstPersonLook look;

    public override void InstallBindings()
    {
        Container.BindInstance(look).AsSingle();
        Container.Bind<FirstPersonLook.ILookDeltaProvider>().To<FirstPersonLookDeltaProviderRouter>().AsSingle();
        var mobileInput = new MovementMobileInputProvider();
        Container.Bind<FirstPersonMovement.IMovementInputProvider>().FromInstance(mobileInput).AsSingle().WhenInjectedInto<MovementInputProviderRouter>();
        Container.Bind<IMovementInputHandler>().FromInstance(mobileInput).AsSingle();
        Container.Bind<FirstPersonMovement.IMovementInputProvider>().To<MovementInputProviderRouter>().AsSingle();
    }
}