using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SoundToggleGAEvent : MonoBehaviour
{
    void Start() => GetComponent<Toggle>().onValueChanged.AddListener(Toggle);

    private void Toggle(bool state)
    {
        var param = new Dictionary<string, object> { { "SoundState", state as object } };
        GameAnalytics.NewDesignEvent("SoundToggle", param);
    }
}