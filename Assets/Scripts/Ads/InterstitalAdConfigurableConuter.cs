using System;
using System.Collections;
using Ads;
using GameAnalyticsSDK;
using UnityEngine;
using Zenject;

public class InterstitalAdConfigurableConuter : MonoBehaviour
{
    [Inject] private IInterstitalAdNavigator adNavigator;
    [SerializeField] private string configKey;
    [SerializeField] private string placement;
    private int invokeTimes = 0;
    private int showInterval = 1;
    private void Start()
    {
        StartCoroutine(SetupConfig());
    }

    private IEnumerator SetupConfig()
    {
        var ready = GameAnalytics.IsRemoteConfigsReady();
        while (!ready)
        {
            yield return new WaitForSeconds(1f);
            ready = GameAnalytics.IsRemoteConfigsReady();
        }

        try
        {
            var configValue = GameAnalytics.GetRemoteConfigsValueAsString(configKey, showInterval.ToString());
            var interval = int.Parse(configValue);
            showInterval = interval;
        }
        catch (Exception e)
        {
            GameAnalytics.NewErrorEvent(GAErrorSeverity.Error, e.ToString());
        }
    }

    public void TryShow()
    {
        if(showInterval==0)
            return;
        
        invokeTimes++;
        if (invokeTimes < showInterval)
            return;

        invokeTimes = 0;
        adNavigator.ShowAd();
        GameAnalytics.NewAdEvent(GAAdAction.Request, GAAdType.Interstitial, "YandexAds", "die");
    }
}
