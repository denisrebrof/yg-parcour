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
            Debug.Log("GetPlayerIdAvailable: " + playerIdRepository.GetPlayerIdAvailable());
            if (!playerIdRepository.GetPlayerIdAvailable())
                return;

            SetupId();
        }

        private void SetupId() => playerIdRepository
            .GetPlayerId()
            .Do(id => Debug.Log("Id received: " + id))
            .Subscribe(id =>
                analytics.SetPlayerId(id)
            ).AddTo(this);
    }
}