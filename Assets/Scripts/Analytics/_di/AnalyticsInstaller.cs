using GameAnalyticsSDK;
using UnityEngine;
using Zenject;

namespace Analytics._di
{
    [CreateAssetMenu(menuName = "Installers/AnalyticsInstaller")]
    public class AnalyticsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameAnalytics gameAnalyticsPrefab;

        public override void InstallBindings()
        {
            SpawnAnalytics();
            BindAnalyticsAdapter();
        }

        private void BindAnalyticsAdapter()
        {
            Container
                .Bind<AnalyticsAdapter>()
#if GAME_ANALYTICS
                .To<GameAnalyticsAdapter>()
#else
                .To<DebugLogAnalyticsAdapter>()
#endif
                .AsSingle();
        }

        private void SpawnAnalytics()
        {
#if GAME_ANALYTICS
            Instantiate(gameAnalyticsPrefab, GameObject.Find("Analytics").transform);
#endif
        }
    }
}