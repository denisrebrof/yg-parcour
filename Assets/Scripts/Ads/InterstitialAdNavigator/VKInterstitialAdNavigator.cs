using Zenject;

namespace Ads.InterstitialAdNavigator
{
    public class VKInterstitialAdNavigator : IInterstitalAdNavigator
    {
        [Inject] private FirstPersonLook look;
        public void ShowAd()
        {
#if VK_SDK
            var instance = VKSDK.instance;
            if(instance==null)
                return;
            
            try
            {
                instance.ShowInterstitial();
                look.SetEnabledState(false);
            }
            catch
            {
            }
#endif
        }
    }
}