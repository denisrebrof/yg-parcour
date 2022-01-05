using Ads;
using GameAnalyticsSDK;
using UnityEngine;
using Zenject;

public class InterstitialOnEnable : MonoBehaviour
{
    [Inject] private IInterstitalAdNavigator adNavigator;
    private void OnEnable()
    {
        adNavigator.ShowAd();
        GameAnalytics.NewAdEvent(GAAdAction.Request, GAAdType.Interstitial, "YandexAds", "default");
    }
}
