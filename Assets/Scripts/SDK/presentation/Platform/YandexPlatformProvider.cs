using Zenject;

namespace SDK.presentation.Platform
{
    public class YandexPlatformProvider: IPlatformProvider
    {
        [Inject] private Plugins.YSDK.YandexSDK sdk; 
        
        public Platform GetCurrentPlatform()
        {
#if YANDEX_SDK
            return sdk.GetIsOnDesktop() ? Platform.Desktop : Platform.Mobile;
#endif
            return Platform.Desktop;
        }
    }
}