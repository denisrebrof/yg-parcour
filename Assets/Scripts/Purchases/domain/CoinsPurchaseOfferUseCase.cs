using System;
using System.Linq;
using JetBrains.Annotations;
using Purchases.domain.model;
using Purchases.domain.repositories;
using UniRx;
using Zenject;

namespace Purchases.domain
{
    public class CoinsPurchaseOfferUseCase
    {
        [Inject] private PurchaseAvailableUseCase purchaseAvailableUseCase;
        [Inject] private IPurchaseRepository purchaseRepository;
        [Inject] private ICoinsPurchaseRepository coinsPurchaseRepository;

        public IObservable<CoinsPurchaseOfferRequestResult> GetOffer()
        {
            var coinsPurchases = purchaseRepository
                .GetPurchases()
                .Where(purchase => purchase.Type == PurchaseType.Coins)
                .OrderBy(purchase => coinsPurchaseRepository.GetCost(purchase.Id))
                .ToList();

            if (coinsPurchases.Count == 0)
                return Observable.Return(CoinsPurchaseOfferRequestResult.Failure);

            return purchaseAvailableUseCase
                .GetPurchaseAvailable(coinsPurchases[0].Id)
                .Select(available => available
                    ? CoinsPurchaseOfferRequestResult.Success(coinsPurchases[0])
                    : CoinsPurchaseOfferRequestResult.Failure
                ).First();
        }

        public class CoinsPurchaseOfferRequestResult
        {
            [CanBeNull] public readonly Purchase Purchase;

            public bool HasResult => Purchase != null;

            private CoinsPurchaseOfferRequestResult([CanBeNull] Purchase purchase)
            {
                Purchase = purchase;
            }

            public static readonly CoinsPurchaseOfferRequestResult Failure = new CoinsPurchaseOfferRequestResult(null);

            public static CoinsPurchaseOfferRequestResult Success(Purchase purchase) =>
                new CoinsPurchaseOfferRequestResult(purchase);
        }
    }
}