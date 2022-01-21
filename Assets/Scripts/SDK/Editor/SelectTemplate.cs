using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace SDK.Editor
{
    public class SelectTemplate : IPreprocessBuildWithReport
    {
        public int callbackOrder => 1;

        public void OnPreprocessBuild(BuildReport report)
        {
            const string templateValue = "Universal2020";
#if POKI_SDK
            const string templateValue = "poki-template";
#elif CRAZY_SDK
            const string templateValue = "Crazy_2020";
#endif
#pragma warning disable 618
            PlayerSettings.SetPropertyString("template", "PROJECT:" + templateValue, BuildTargetGroup.WebGL);
#pragma warning restore 618
        }
    }
}