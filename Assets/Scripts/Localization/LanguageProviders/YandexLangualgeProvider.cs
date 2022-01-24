using Zenject;

namespace Localization.LanguageProviders
{
    public class YandexLanguageProvider: ILanguageProvider
    {
        [Inject] private Plugins.YSDK.YandexSDK sdk;
        private Language defaultLanguage = Language.English;
        
        public Language GetCurrentLanguage()
        {
#if YANDEX_SDK
            var lang = sdk.GetLanguage();
            return lang switch
            {
                "ru" => Language.Russian,
                "en" => Language.English,
                _ => defaultLanguage
            };
#endif
            return defaultLanguage;
        }
    }
}