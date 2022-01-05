using GameAnalyticsSDK;
using UnityEngine;
using Zenject;

public class InterstitialEventListener : MonoBehaviour
{
    [Inject] private FirstPersonLook look;
    [Inject] private IInterstitialEventProvider eventProvider;

    private void Start()
    {
        eventProvider.SetInterstitialFailedAction(OnFailed);
        eventProvider.SetInterstitialShownAction(OnShown);
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