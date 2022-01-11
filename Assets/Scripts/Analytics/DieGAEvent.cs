using GameAnalyticsSDK;
using Levels.domain.repositories;
using UnityEngine;
using Zenject;

public class DieGAEvent : MonoBehaviour
{
    [Inject] private ICurrentLevelRepository currentLevelRepository;
    
    public void Send()
    {
        var levelNum = currentLevelRepository.GetCurrentLevel().ID;
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Level_" + levelNum);
    }
}