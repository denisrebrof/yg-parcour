using System;

namespace Ads.InterstitialEventProvider
{
    public class StubInterstitialEventProvider: IInterstitialEventProvider
    {
        public void SetInterstitialShownAction(Action onShown)
        {
            //do nothing
        }

        public void SetInterstitialFailedAction(Action<string> onFailed)
        {
            //do nothing
        }
    }
}