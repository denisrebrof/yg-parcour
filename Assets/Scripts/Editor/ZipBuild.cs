using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class ZipBuild
{
    [PostProcessBuild(20)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (target != BuildTarget.WebGL)
            return;

#if YANDEX_SDK || POKI_SDK
        var projectRootPath = Directory.GetParent(Application.dataPath)?.FullName;
        var script = Directory.GetFiles(projectRootPath).First(file => file.Contains("zip_build"));
        var archiveName = pathToBuiltProject + "_zipped";
        RunCmd("C:/Python27amd64/python.exe", $"{script} {pathToBuiltProject} {archiveName}");
#endif
    }

    private static void RunCmd(string cmd, string args)
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = cmd;//cmd is full path to python.exe
        start.Arguments = args;//args is path to .py file and any cmd line args
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        using(Process process = Process.Start(start))
        {
            using(StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                Console.Write(result);
            }
        }
    }
}