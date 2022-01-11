using System;
using UniRx;
using UnityEngine;

namespace Ads.InterstitialAdNavigator
{
    public class DebugLogInterstitialAdNavigator: IInterstitalAdNavigator
    {
        public IObservable<ShowInterstitialResult> ShowAd()
        {
            Debug.Log("Debug Show interstitial");
            return Observable.Return(ShowInterstitialResult.Success);
        }
    }
}