using System.Collections.Generic;
using GameAnalyticsSDK;
using Levels.domain.repositories;
using UnityEngine;
using Zenject;

public class QuitGameEvent : MonoBehaviour
{
    [Inject] private ICurrentLevelRepository currentLevelRepository;

    private void OnApplicationQuit()
    {
        var levelNum = currentLevelRepository.GetCurrentLevel().ID;
        var param = new Dictionary<string, object>();
        param.Add("level", levelNum as object);
        GameAnalytics.NewDesignEvent("Quit", param);
    }
}