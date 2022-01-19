using Gameplay.Input;
using Gameplay.Inputs.Jump;
using SDK.presentation.Platform;
using Zenject;

namespace Gameplay.Inputs
{
    public class JumpInputProviderRouter: global::Jump.IJumpInputProvider
    {
        private global::Jump.IJumpInputProvider desktopProvider = new JumpInputDesktopProvider(); 
        private global::Jump.IJumpInputProvider mobileProvider = new JumpInputMobileProvider(); 
        [Inject] private IPlatformProvider platformProvider;

        private bool initialized = false;
        private bool isOnDesktop = true;
        
        public bool GetHasJumpInput()
        {
            if (!initialized)
            {
                isOnDesktop = platformProvider.GetCurrentPlatform() == Platform.Desktop;
                initialized = true;
            }
            return isOnDesktop? desktopProvider.GetHasJumpInput() : mobileProvider.GetHasJumpInput();
        }
    }
}