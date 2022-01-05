using System;

public interface IInterstitialEventProvider
{
    public void SetInterstitialShownAction(Action onShown);
    public void SetInterstitialFailedAction(Action<string> onFailed);
}