﻿using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo("Level Select");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Rules()
    {
        sceneFader.FadeTo("Rules");
    }
}
