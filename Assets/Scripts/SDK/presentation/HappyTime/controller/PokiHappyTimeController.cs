using Zenject;

namespace SDK.presentation.HappyTime.controller
{
#if POKI_SDK
    public class PokiHappyTimeController: IHappyTimeController
    {
        [Inject] private PokiUnitySDK sdk;

        public void SetHappyTime(float intencity = 0.5f)
        {
            sdk.happyTime(intensity);
        }
    }
#endif
}