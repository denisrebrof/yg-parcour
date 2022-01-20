using CrazyGames;
using SDK.presentation.HappyTime;
using SDK.presentation.HappyTime.controller;
using SDK.presentation.Platform;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installers/SDKInstaller")]
public class SDKInstaller : ScriptableObjectInstaller
{
    [SerializeField] private YandexSDK yandexSDK;
    [SerializeField] private VKSDK vksdk;
    [SerializeField] private PokiUnitySDK pokiUnitySDK;

    [SerializeField] private CrazySDK crazySDK;

    public override void InstallBindings()
    {
        InstallSDK();
        InstallHappyTime();
        InstallPlatformProvider();
    }

    private void InstallHappyTime()
    {
        Container
            .Bind<IHappyTimeController>()
#if POKI_SDK
                .To<PokiHappyTimeController>()
#elif CRAZY_SDK
                .To<CrazyHappyTimeController>()
#else
            .To<DebugLogHappyTimeController>()
#endif
            .AsSingle();
    }

    private void InstallSDK()
    {
#if YANDEX_SDK
            var instance = Instantiate(yandexSDK);
            instance.gameObject.name = "YandexSDK";
            Container.Bind<YandexSDK>().FromInstance(instance).AsSingle();
#elif VK_SDK
        var instance = Instantiate(vksdk);
        instance.gameObject.name = "VKSDK";
        Container.Bind<VKSDK>().FromInstance(instance).AsSingle();
#elif POKI_SDK
        var instance = Instantiate(pokiUnitySDK);
        instance.gameObject.name = "POKI_SDK";
        Container.Bind<PokiUnitySDK>().FromInstance(instance).AsSingle();
#elif CRAZY_SDK
        var instance = Instantiate(crazySDK);
        instance.gameObject.name = "CRAZY_SDK";
        Container.Bind<CrazySDK>().FromInstance(instance).AsSingle();
#endif
    }

    private void InstallPlatformProvider()
    {
#if YANDEX_SDK && !UNITY_EDITOR
        Container.Bind<IPlatformProvider>().To<YandexPlatformProvider>().AsSingle();
#elif UNITY_EDITOR
        Container.Bind<IPlatformProvider>().To<MobilePlatformProvider>().AsSingle();
#else
        Container.Bind<IPlatformProvider>().To<DesktopPlatformProvider>().AsSingle();
#endif
    }
}