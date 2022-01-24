using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;
using Zenject;

public class GameAnalyticsSetPlayerId : MonoBehaviour
{

    public void SetPlayerId(string id)
    {
        #if GAME_ANALYTICS
            GameAnalytics.SetCustomId(id);
        #endif
    }
}
