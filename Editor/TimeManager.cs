using UnityEditor;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

[InitializeOnLoad]
public static class TimeManager
{
    [MenuItem("Tools/Hakan Yuksel/Stop %&#8")]
    public static void StopTime()
    {
        Time.timeScale = 0;
    }

    [MenuItem("Tools/Hakan Yuksel/Slower %&#9")]
    public static void SlowDown()
    {
        if (Time.timeScale - 0.1f < 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale -= 0.1f;
        }
    }

    [MenuItem("Tools/Hakan Yuksel/Faster %&#0")]
    public static void SpeedUp()
    {
        Time.timeScale += 0.1f;
    }

}
