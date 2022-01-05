using Ads.AdNavigator;
using Ads.InterstitialAdNavigator;
using Ads.InterstitialEventProvider;
using UnityEngine;
using Zenject;

namespace Ads._di
{
    [CreateAssetMenu(fileName = "AdsInstaller", menuName = "Installers/AdsInstaller")]
    public class AdsInstaller : ScriptableObjectInstaller<AdsInstaller>
    {
        public override void InstallBindings()
        {
            #if YANDEX_SDK
            Container.Bind<IInterstitalAdNavigator>().To<YandexInterstitialAdNavigator>().AsSingle();
            Container.Bind<IInterstitialEventProvider>().To<YandexInterstitialEventProvider>().AsSingle();
            #elif VK_SDK
            Container.Bind<IInterstitalAdNavigator>().To<VKInterstitialAdNavigator>().AsSingle();
            Container.Bind<IInterstitialEventProvider>().To<VKInterstitialEventProvider>().AsSingle();
            #else
            Container.Bind<IInterstitalAdNavigator>().To<DebugLogInterstitialAdNavigator>().AsSingle();
            Container.Bind<IInterstitialEventProvider>().To<StubInterstitialEventProvider>().AsSingle();
            #endif
        }
    }
}