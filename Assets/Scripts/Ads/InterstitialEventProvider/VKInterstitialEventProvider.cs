using System;

namespace Ads.InterstitialEventProvider
{
    public class VKInterstitialEventProvider: IInterstitialEventProvider
    {
        public void SetInterstitialShownAction(Action onShown)
        {
            #if VK_SDK
            VKSDK.instance.onInterstitialShown += onShown;
            #endif
        }

        public void SetInterstitialFailedAction(Action<string> onFailed)
        {
            #if VK_SDK
            VKSDK.instance.onInterstitialFailed += onFailed;
            #endif
        }
    }
}