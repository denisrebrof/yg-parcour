using UnityEngine;
using Zenject;

public class InterstitialLookHandler : MonoBehaviour
{
    [Inject] private FirstPersonLook look;
    [Inject] private IInterstitialEventProvider eventProvider;

    private bool uiShownState = false;

    public void SetUIShownState(bool shown)
    {
        uiShownState = shown;
    }

    private void Start()
    {
        #if VK_SDK
        eventProvider.SetInterstitialFailedAction(OnFailed);
        eventProvider.SetInterstitialShownAction(OnShown);
        #endif
    }

    private void OnShown()
    {
        Debug.Log("LookHandler.OnShown " + uiShownState);
        if (!uiShownState)
            look.SetEnabledState(true);
    }

    private void OnFailed(string error)
    {
        Debug.Log("LookHandler.OnFailed" + uiShownState);
        if (!uiShownState)
            look.SetEnabledState(true);
    }
}