using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace SDK.Editor
{
    public static class SwitchSDKPlatform
    {
        private static readonly BuildTargetGroup targetGroup = BuildTargetGroup.WebGL;

        private static readonly Dictionary<SDKProvider.SDKType, string> Symbols =
            new Dictionary<SDKProvider.SDKType, string>()
            {
                {SDKProvider.SDKType.Yandex, "YANDEX_SDK"},
                {SDKProvider.SDKType.Vk, "VK_SDK"},
                {SDKProvider.SDKType.Poki, "POKI_SDK"},
                {SDKProvider.SDKType.None, ""}
            };

        [MenuItem("Platform/Set Yandex", false)]
        public static void SetYandex()
        {
            CleanDefineSymbols();
            SetPlatformDefineSymbol(SDKProvider.SDKType.Yandex);
        }

        [MenuItem("Platform/Set VK", false)]
        public static void SetVk()
        {
            CleanDefineSymbols();
            SetPlatformDefineSymbol(SDKProvider.SDKType.Vk);
        }

        [MenuItem("Platform/Set None", false)]
        public static void SetNone()
        {
            CleanDefineSymbols();
        }

        private static void CleanDefineSymbols()
        {
            var currData = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);
            var definitions = currData.Split(';').ToList();
            var sdkDefinitions = Symbols.Values.ToList();
            definitions = definitions.Where(definition => !sdkDefinitions.Contains(definition)).ToList();
            var cleanedData = String.Join(';', definitions);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, cleanedData);
        }

        private static void SetPlatformDefineSymbol(SDKProvider.SDKType type)
        {
            string currData = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);
            if (currData.Length > 0 && !currData[^1].Equals(';'))
            {
                currData += ';';
            }
            currData += Symbols[type];
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, currData);
        }
    }
}