using System;

namespace Ads.InterstitialEventProvider
{
    public class YandexInterstitialEventProvider: IInterstitialEventProvider
    {
        public void SetInterstitialShownAction(Action onShown)
        {
            #if YANDEX_SDK
            YandexSDK.instance.onInterstitialShown += onShown;
            #endif
        }

        public void SetInterstitialFailedAction(Action<string> onFailed)
        {
            #if YANDEX_SDK
            YandexSDK.instance.onInterstitialFailed += onFailed;
            #endif
        }
    }
}