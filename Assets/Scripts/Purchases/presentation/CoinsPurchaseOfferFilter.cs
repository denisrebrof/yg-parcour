using Purchases.domain;
using Purchases.domain.model;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Purchases.presentation
{
    public class CoinsPurchaseOfferFilter: MonoBehaviour
    {
        [Inject] private CoinsPurchaseOfferUseCase useCase;
        [SerializeField] private UnityEvent<Purchase> onFilterPass;
        [SerializeField] private UnityEvent onFilterFailed;
        
        public void PushEvent() => useCase.GetOffer().Subscribe(HandleOffer).AddTo(this);

        private void HandleOffer(CoinsPurchaseOfferUseCase.CoinsPurchaseOfferRequestResult result)
        {
            if (result.HasResult) onFilterPass.Invoke(result.Purchase);
            else onFilterFailed.Invoke();
        }
    }
}