using SDK.presentation.Platform;
using UnityEngine;
using Zenject;

namespace Gameplay.Inputs
{
    public class MovementInputProviderRouter : FirstPersonMovement.IMovementInputProvider
    {
        private FirstPersonMovement.IMovementInputProvider desktopProvider = new MovementDesktopInputProvider();
        [Inject] private FirstPersonMovement.IMovementInputProvider mobileProvider;
        [Inject] private IPlatformProvider platformProvider;

        private bool initialized = false;
        private bool isOnDesktop = true;

        public Vector2 GetInput()
        {
            if (!initialized)
            {
                isOnDesktop = platformProvider.GetCurrentPlatform() == Platform.Desktop;
                initialized = true;
            }
            return isOnDesktop ? desktopProvider.GetInput() : mobileProvider.GetInput();
        }
    }
}