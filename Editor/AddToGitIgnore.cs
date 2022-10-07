using UnityEditor;
using System.IO;
using System.Diagnostics;

public static class AddToGitIgnore
{
    [MenuItem("Assets/Add To GitIgnore")]
    private static void AddToGitIgnoreFile()
    {
        string path = "Assets/.gitignore";
        StreamWriter writer = new StreamWriter(path, true);
        writer.Close();

        StreamReader reader = new StreamReader(path, true);
        string previous = reader.ReadToEnd();
        reader.Close();

        writer = new StreamWriter(path, true);

        foreach (UnityEngine.Object item in Selection.objects)
        {
            if (!previous.Contains(item.name))
            {
                writer.WriteLine(item.name);
                writer.WriteLine(item.name + ".meta");
            }
        }

        writer.Close();
    }

    [MenuItem("Assets/Remove From GitIgnore")]
    private static void RemoveFromGitIgnoreFile()
    {
        string path = "Assets/.gitignore";
        StreamWriter writer = new StreamWriter(path, true);
        writer.Close();

        StreamReader reader = new StreamReader(path, true);
        string previous = reader.ReadToEnd();
        reader.Close();

        writer = new StreamWriter(path, false);

        foreach (UnityEngine.Object item in Selection.objects)
        {
            if (previous.Contains(item.name + "\r\n"))
            {
                Debug.Write(item.name);

                previous = previous.Replace(item.name + "\r\n", "");
                previous = previous.Replace(item.name + ".meta\r\n", "");
            }
        }
        writer.Write(previous);
        writer.Close();
    }
}
