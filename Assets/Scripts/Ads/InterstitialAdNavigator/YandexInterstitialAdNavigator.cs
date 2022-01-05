namespace Ads.InterstitialAdNavigator
{
    public class YandexInterstitialAdNavigator : IInterstitalAdNavigator
    {
        public void ShowAd()
        {
#if YANDEX_SDK
            var instance = YandexSDK.instance;
            if(instance==null)
                return;
            
            try
            {
                instance.ShowInterstitial();
            }
            catch
            {
            }
#endif
        }
    }
}