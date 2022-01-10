using System;
using Zenject;

namespace Ads.InterstitialAdNavigator
{
    public class PokiInterstitialAdNavigatorProvider : IInterstitalAdNavigator, IInterstitialEventProvider
    {
#if POKI_SDK
        [Inject] private PokiUnitySDK sdk;
#endif

        private Action interstitialShownAction;
        private Action<string> interstitialFailedAction;

        public void ShowAd()
        {
            if (sdk.adsBlocked() || sdk.isShowingAd)
            {
                interstitialFailedAction("adsBlocked");
                return;
            }
            
            if (sdk.isShowingAd)
            {
                interstitialFailedAction("isShowingAd");
                return;
            }
                
            sdk.commercialBreakCallBack += onShown;
            sdk.commercialBreak();
        }

        private void onShown()
        {
            interstitialShownAction.Invoke();
        }

        public void SetInterstitialShownAction(Action onShown) => interstitialShownAction += onShown;

        public void SetInterstitialFailedAction(Action<string> onFailed) => interstitialFailedAction += onFailed;
    }
}