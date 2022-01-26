using System;
using Purchases.domain;
using RewardedVideo.domain;
using RewardedVideo.domain.model;
using UniRx;
using UnityEngine;
using Zenject;

namespace Purchases.adapters
{
    public class RewardedVideoPresenterAdapter : MonoBehaviour, RewardedVideoPurchaseUseCase.IRewardedVideoPurchasePresenterAdapter
    {
        [Inject] private IRewardedVideoNavigator rewardedVideoNavigator;

        public void ShowInterstitial(Action<bool> successCallback) => rewardedVideoNavigator
            .ShowRewardedVideo()
            .Subscribe(result =>
                successCallback.Invoke(result == ShowRewardedVideoResult.Success)
            ).AddTo(this);
    }
}