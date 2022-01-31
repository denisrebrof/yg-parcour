using System;
using SDK.PlayerData.domain;
using UniRx;

namespace SDK.PlayerData.data
{
    public class EmptyPlayerIdRepository: IPlayerIdRepository
    {
        public bool GetPlayerIdAvailable() => false;

        public IObservable<string> GetPlayerId() => Observable.Never<string>();
    }
}