using System;
using System.Collections;
using Analytics;
using GameAnalyticsSDK;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ads.presentation.InterstitialAdNavigator.decorators
{
    public class InterstitialAdNavigatorCounterDecorator : MonoBehaviour, IInterstitalAdNavigator
    {
        [Inject] private IInterstitalAdNavigator adNavigator;
        [Inject] private AnalyticsAdapter analytics;
        [SerializeField] private string configKey;
        [SerializeField] private string configKeyY;
        [SerializeField] private string configKeyV;
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
                string key = configKey;
#if YANDEX_SDK
                key = configKeyY;
#elif VK_SDK
                key = configKeyV;
#endif
                var configValue = GameAnalytics.GetRemoteConfigsValueAsString(key, showInterval.ToString());
                var interval = int.Parse(configValue);
                showInterval = interval;
            }
            catch (Exception e)
            {
                analytics.SendErrorEvent(e.ToString());
            }
        }

        public IObservable<ShowInterstitialResult> ShowAd()
        {
            if (showInterval == 0)
                return Observable.Return(new ShowInterstitialResult(false, "zero show interval"));

            invokeTimes++;
            if (invokeTimes < showInterval)
                Observable.Return(new ShowInterstitialResult(false, "period not reached"));

            invokeTimes = 0;
            return adNavigator.ShowAd();
        }
    }
}