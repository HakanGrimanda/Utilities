using UnityEditor;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public static class AddToGitIgnore
{
    private static List<string> DoesListContainsLine(List<string> lines, string lineToBeLookedFor, bool shouldAdd)
    {
        List<string> newLines = new();
        foreach (string line in lines)
        {
            if (lineToBeLookedFor != line)
            {
                newLines.Add(line);
            }
        }

        if (shouldAdd)
        {
            newLines.Add(lineToBeLookedFor);
        }
        return newLines;
    }

    private static void AddRemoveFromGitIgnore(bool shouldAdd)
    {
        string path = "Assets/.gitignore";
        StreamWriter writer = new StreamWriter(path, true);
        writer.Close();

        StreamReader reader = new(path, true);
        List<string> previous = new();
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            previous.Add(line);
        }
        reader.Close();

        foreach (UnityEngine.Object item in Selection.objects)
        {
            previous = DoesListContainsLine(previous, item.name, shouldAdd);
            previous = DoesListContainsLine(previous, item.name + ".meta", shouldAdd);
        }
        writer = new StreamWriter(path, false);
        foreach (string _line in previous)
        {
            writer.WriteLine(_line);
        }
        writer.Close();
    }

    [MenuItem("Assets/Add To GitIgnore")]
    private static void AddToGitIgnoreFile()
    {
        AddRemoveFromGitIgnore(true);
    }

    [MenuItem("Assets/Remove From GitIgnore")]
    private static void RemoveFromGitIgnoreFile()
    {
        AddRemoveFromGitIgnore(false);
    }
}
