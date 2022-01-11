using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

public class GameAnalyticsProgressionEvent : MonoBehaviour
{
    [SerializeField] private GAProgressionStatus m_status;
    
    public void Send()
    {
        // GameAnalytics.NewProgressionEvent(m_status, );
    }
}
