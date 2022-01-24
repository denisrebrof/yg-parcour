using System.Collections.Generic;
using UnityEditor;
using Utils.Editor;

namespace SDK.Editor
{
    public class SwitchSDKPlatform : DefineSymbolsFieldController<SDKProvider.SDKType>
    {
        protected override Dictionary<SDKProvider.SDKType, string> Symbols => new()
        {
            { SDKProvider.SDKType.Yandex, "YANDEX_SDK" },
            { SDKProvider.SDKType.Vk, "VK_SDK" },
            { SDKProvider.SDKType.Poki, "POKI_SDK" },
            { SDKProvider.SDKType.None, "" }
        };

        [MenuItem("Platform/Set Yandex", false)]
        public static void SetYandex() => SetSDKType(SDKProvider.SDKType.Yandex);

        [MenuItem("Platform/Set VK", false)]
        public static void SetVk() => SetSDKType(SDKProvider.SDKType.Vk);

        [MenuItem("Platform/Set None", false)]
        public static void SetNone() => SetSDKType(SDKProvider.SDKType.None);

        private static void SetSDKType(SDKProvider.SDKType type) => new SwitchSDKPlatform().SetVariant(type);
    }
}