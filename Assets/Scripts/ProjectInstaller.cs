using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private FirstPersonLook look;
    public override void InstallBindings()
    {
        Container.BindInstance(look).AsSingle();
    }
}