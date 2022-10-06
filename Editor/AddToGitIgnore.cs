using UnityEditor;
using System.IO;
public static class AddToGitIgnore
{
    [MenuItem("Assets/AddToGitIgnore")]
    private static void AddToGitIgnoreFile()
    {
        string path = "Assets/.gitignore";
        StreamWriter writer = new StreamWriter(path, true);
        writer.Close();

        StreamReader reader = new StreamReader(path, true);
        string previous=reader.ReadToEnd();
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
}
