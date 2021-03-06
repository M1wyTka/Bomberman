﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.Confirm);
        LevelManager.Instance.LoadGameLvl();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
