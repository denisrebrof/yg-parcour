using System;
using UniRx;
using Zenject;

namespace Ads.InterstitialAdNavigator
{
    public class YandexInterstitialNavigatorHitsDecorator : IInterstitalAdNavigator
    {
        [Inject] private IInterstitalAdNavigator adNavigator;
        [Inject] private YandexSDK instance;

        public IObservable<ShowInterstitialResult> ShowAd()
        {
            instance.AddHit("TryShowInterstitial");
            return adNavigator.ShowAd().Do(HandleResult);
        }

        private void HandleResult(ShowInterstitialResult result)
        {
            var hit = "ShowInterstitial/";
            hit += result.isSuccess ? "Success" : "NotSuccess";
            instance.AddHit(hit);
        }
    }
}