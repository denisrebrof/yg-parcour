using Analytics.levels;
using Analytics.session;
using Levels.domain.repositories;
using UnityEngine;
using Zenject;

namespace Analytics.presentation
{
    public class SessionEventsHandler : MonoBehaviour
    {
        [Inject] private AnalyticsAdapter analytics;
        [Inject] private ICurrentLevelRepository currentLevelRepository;

        private void Awake() => SendEvent(SessionEvent.Start);

        private void OnApplicationQuit() => SendEvent(SessionEvent.Quit);

        private void SendEvent(SessionEvent sessionEvent)
        {
            var levelId = currentLevelRepository.GetCurrentLevel().ID;
            var pointer = new LevelPointer(levelId);
            analytics.SendSessionEvent(sessionEvent, pointer);
        }
    }
}