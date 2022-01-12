using GameAnalyticsSDK;
using UnityEngine;

public class GameAnalyticsInitializer : MonoBehaviour
{
    void Awake()
    {
        GameAnalytics.Initialize();
        GameAnalytics.NewDesignEvent("Game Session Started");
    }
}