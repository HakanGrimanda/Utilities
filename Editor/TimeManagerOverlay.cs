using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor.EditorTools;
using UnityEditor.Toolbars;
using UnityEditor.Overlays;
using UnityEngine.UIElements;
using UnityEditor;
using Unity.VisualScripting;

[EditorToolbarElement(id, typeof(SceneView))]
public class PauseTheGameButton : EditorToolbarButton
{
    public const string id = "Time Manager/PauseButton";
    public PauseTheGameButton()
    {
        text = "II";
        icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/CreateCubeIcon.png");
        tooltip = "Pauses and Resumes The Game";
        clicked += OnClick;
    }
    
    public void RefreshText()
    {
        if (Time.timeScale != 1)
        {
            text = ">";
        }
        else
        {
            text = "II";
        }
    }
    void OnClick()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale= 1;
        }
        else
        {
            TimeManager.StopTime();
        }

        RefreshText();
    }
}

[EditorToolbarElement(id, typeof(SceneView))]
class SpeedUpTheGameButton : EditorToolbarButton
{
    public const string id = "Time Manager/SpeedUpButton";
    public SpeedUpTheGameButton()
    {
        text = ">>";
        tooltip = "Speed Ups The Game";
        clicked += OnClick;
    }

    void OnClick()
    {
        TimeManager.SpeedUp();
    }
}

[EditorToolbarElement(id, typeof(SceneView))]
class SlowDownTheGameButton : EditorToolbarButton
{
    public const string id = "Time Manager/SlowDownButton";
    public SlowDownTheGameButton()
    {
        text = "<<";
        tooltip = "Slow Downs The Game";
        clicked += OnClick;
    }

    void OnClick()
    {
        TimeManager.SlowDown();
    }
}

[Overlay(typeof(SceneView), "Time Manager")]
public class TimeManagerOverlay : ToolbarOverlay
{
    TimeManagerOverlay() : base(
        PauseTheGameButton.id,
        SlowDownTheGameButton.id,
        SpeedUpTheGameButton.id
        )
    { }
}
