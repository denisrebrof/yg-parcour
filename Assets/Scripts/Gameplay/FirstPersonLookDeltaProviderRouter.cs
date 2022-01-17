using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class FirstPersonLookDeltaProviderRouter: FirstPersonLook.ILookDeltaProvider
    {
        private FirstPersonLook.ILookDeltaProvider desktopProvider = new FirstPersonLookDesktopDeltaProvider(); 
        private FirstPersonLook.ILookDeltaProvider mobileProvider = new FirstPersonLookMobileDeltaProvider(); 
#if YANDEX_SDK
        [Inject] private YandexSDK sdk;
#endif

        private bool initialized = false;
        private bool isOnDesktop = false;
        
        public Vector2 GetDelta()
        {
            if (!initialized)
            {
#if YANDEX_SDK
                isOnDesktop = sdk.GetIsOnDesktop();
#endif
                initialized = true;
            }
            return isOnDesktop? desktopProvider.GetDelta() : mobileProvider.GetDelta();
        }
    }
}