using CrazyGames;
using Zenject;

namespace SDK.presentation.HappyTime.controller
{
#if CRAZY_SDK
    public class CrazyHappyTimeController : IHappyTimeController
    {
        [Inject] private CrazySDK sdk;

        public void SetHappyTime(float intencity = 0.5f) => sdk.HappyTime();
    }
#endif
}