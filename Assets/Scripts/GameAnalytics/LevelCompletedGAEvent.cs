using GameAnalyticsSDK;
using Levels.domain.repositories;
using UnityEngine;
using Zenject;

public class LevelCompletedGAEvent : MonoBehaviour
{
    [Inject] private ICurrentLevelRepository currentLevelRepository;
    
    public void Send()
    {
        var levelNum = currentLevelRepository.GetCurrentLevel().ID;
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level_" + levelNum);
    }
}
