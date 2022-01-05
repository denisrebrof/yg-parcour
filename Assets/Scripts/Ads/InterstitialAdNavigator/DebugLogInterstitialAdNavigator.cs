using UnityEngine;

namespace Ads.AdNavigator
{
    public class DebugLogInterstitialAdNavigator: IInterstitalAdNavigator
    {
        public void ShowAd() => Debug.Log("Debug Show interstitial");
    }
}