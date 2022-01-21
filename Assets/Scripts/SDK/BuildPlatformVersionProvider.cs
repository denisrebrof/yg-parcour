using UnityEngine;

namespace SDK
{
    public static  class BuildPlatformVersionProvider
    {
        public static string GetBuildVersion()
        {
            var sdkPostfix = SDKProvider.GetSDK() switch
            {
                SDKProvider.SDKType.Yandex => "y",
                SDKProvider.SDKType.Vk => "v",
                SDKProvider.SDKType.Poki => "p",
                _ => string.Empty
            };

            var version = Application.version;
            if (!string.IsNullOrEmpty(sdkPostfix))
                version += "." + sdkPostfix;

            return version;
        }
    }
}