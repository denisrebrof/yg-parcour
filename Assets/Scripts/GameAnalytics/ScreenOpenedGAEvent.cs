using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

public class ScreenOpenedGAEvent : MonoBehaviour
{
    private bool initialized = false;
    [SerializeField] private string screenName;
    
    
    Dictionary<string, object> fields = new();

    private void Awake()
    {
        fields.Add("screenName", screenName);
    }

    private void OnEnable()
    {
        if(string.IsNullOrEmpty(screenName))
            return;
        
        if (!initialized)
        {
            initialized = true;
            return;
        }

        GameAnalytics.NewDesignEvent("ScreenOpen", fields);
    }
}
