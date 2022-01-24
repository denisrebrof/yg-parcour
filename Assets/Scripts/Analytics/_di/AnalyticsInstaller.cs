using UnityEngine;
using Zenject;

namespace Analytics._di
{
    [CreateAssetMenu(menuName = "Installers/AnalyticsInstaller")]
    public class AnalyticsInstaller : ScriptableObjectInstaller
    {
#if GAME_ANALYTICS
        [SerializeField] private GameAnalytics gameAnalyticsPrefab;
#endif

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
#elif DEBUG_ANALYTICS
                .FromInstance(new DebugLogAnalyticsAdapter(true))
#else
                .FromInstance(new DebugLogAnalyticsAdapter(false))
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