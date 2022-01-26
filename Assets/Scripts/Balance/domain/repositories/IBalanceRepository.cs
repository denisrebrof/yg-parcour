using System;

namespace Balance.domain.repositories
{
    public interface IBalanceRepository
    {
        int GetBalance();
        IObservable<int> GetBalanceFlow();
        void Add(int value);
        void Remove(int value);
    }
}