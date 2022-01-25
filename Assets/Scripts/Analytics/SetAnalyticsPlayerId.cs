using SDK.PlayerData.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Analytics
{
    public class SetAnalyticsPlayerId : MonoBehaviour
    {
        [Inject] private AnalyticsAdapter analytics;
        [Inject] private IPlayerIdRepository playerIdRepository;

        private void Start()
        {
            if (!playerIdRepository.GetPlayerIdAvailable())
                return;

            SetupId();
        }

        private void SetupId() => playerIdRepository
            .GetPlayerId()
            .Subscribe(id =>
                analytics.SetPlayerId(id)
            ).AddTo(this);
    }
}