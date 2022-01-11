using System;
using Ads;
using GameAnalyticsSDK;
using UniRx;
using Zenject;

namespace Analytics
{
    public class InterstitialAdNavigatorAnalyticsDecorator : IInterstitalAdNavigator
    {
        [Inject] 
        private IInterstitalAdNavigator target;

        public IObservable<ShowInterstitialResult> ShowAd()
        {
            GameAnalytics.NewAdEvent(GAAdAction.Request, GAAdType.Interstitial, "YandexAds", "die");
            return target.ShowAd().Do(result =>
                {
                    if (!result.isSuccess)
                        OnFailed(result.error);
                    else
                        OnShown();
                }
            );
        }

        private void OnShown()
        {
            GameAnalytics.NewAdEvent(
                GAAdAction.Show,
                GAAdType.Interstitial,
                "YandexAds",
                "default"
            );
        }

        private void OnFailed(string error)
        {
            GameAnalytics.NewAdEvent(
                GAAdAction.FailedShow,
                GAAdType.Interstitial,
                "YandexAds",
                "default"
            );
        }
    }
}