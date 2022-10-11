using UnityEditor;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

[InitializeOnLoad]
public static class TimeManager
{
    
    [MenuItem("Tools/Hakan Yuksel/Stop %&#8")]
    private static void StopTime()
    {
        Time.timeScale = 0;
    }

    [MenuItem("Tools/Hakan Yuksel/Slower %&#9")]
    private static void MakeSlower()
    {
        Time.timeScale -= 0.1f;
    }

    [MenuItem("Tools/Hakan Yuksel/Faster %&#0")]
    private static void MakeFaster()
    {
        Time.timeScale += 0.1f;
    }

}
