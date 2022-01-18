using Gameplay.Input;
using SDK.presentation.Platform;
using UnityEngine;
using Zenject;

namespace Gameplay.Inputs
{
    public class FirstPersonLookDeltaProviderRouter: FirstPersonLook.ILookDeltaProvider
    {
        private FirstPersonLook.ILookDeltaProvider desktopProvider = new FirstPersonLookDesktopDeltaProvider(); 
        private FirstPersonLook.ILookDeltaProvider mobileProvider = new FirstPersonLookMobileDeltaProvider(); 
        [Inject] private IPlatformProvider platformProvider;

        private bool initialized = false;
        private bool isOnDesktop = true;
        
        public Vector2 GetDelta()
        {
            if (!initialized)
            {
                isOnDesktop = platformProvider.GetCurrentPlatform() == Platform.Desktop;
                initialized = true;
            }
            return isOnDesktop? desktopProvider.GetDelta() : mobileProvider.GetDelta();
        }
    }
}