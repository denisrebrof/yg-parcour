using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ads
{
    public class InterstitialAdNavigatorLockLookDecorator : MonoBehaviour, IInterstitalAdNavigator
    {
        [Inject] private FirstPersonLook look;
        [Inject] private IInterstitalAdNavigator Target;

        private bool uiShownState = false;

        public void SetUIShownState(bool shown) => uiShownState = shown;

        public IObservable<ShowInterstitialResult> ShowAd() => Target.ShowAd().Do(_ =>
            {
                if (!uiShownState) look.SetEnabledState(true);
            }
        );
    }
}