using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public static class FillWgl
{
    [PostProcessBuild(10)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (target != BuildTarget.WebGL)
            return;

        var files = Directory.GetFiles(pathToBuiltProject);
        var indexFiles = files.Where(file => file.Contains("index"));
        foreach (var indexFileName in indexFiles)
        {
            EditJsCode(indexFileName);
        }
    }

    private static void EditJsCode(string filePath)
    {
        var lines = File.ReadAllLines(filePath).ToList();

        var closureHeadIndex = lines.FindIndex(str => str.Contains("</head>"));
        lines.InsertRange(closureHeadIndex, HeadLines);

        var bodyIndex = lines.FindIndex(str => str.Contains("<body>"));
        lines.InsertRange(bodyIndex + 1, BodyLines);

        File.WriteAllLines(filePath, lines.ToArray());
    }

    private static string[] HeadLines
    {
        get
        {
            string headFilePath = "";

#if YANDEX_SDK
            headFilePath = "insertHeadJsY";
#elif VK_SDK
            headFilePath = "insertHeadJsV";
#else
            Debug.Log("empty head");
            return Array.Empty<string>();
#endif
            return ReadLinesFromFile(headFilePath);
        }
    }

    private static string[] BodyLines
    {
        get
        {
            
            string bodyFilePath = "";
#if YANDEX_SDK
            bodyFilePath = "insertBodyJsY";
#elif VK_SDK
            bodyFilePath = "insertBodyJsV";
#else
            Debug.Log("empty body");
            return Array.Empty<string>();
#endif
            return ReadLinesFromFile(bodyFilePath);
        }
    }

    private static string[] ReadLinesFromFile(string filenameUniquePart)
    {
        var projectRootPath = Directory.GetParent(Application.dataPath)?.FullName;
        if (projectRootPath == null)
            throw new InvalidOperationException();

        var container = Directory.GetFiles(projectRootPath).First(file => file.Contains(filenameUniquePart));
        return File.ReadAllLines(container);
    }
}