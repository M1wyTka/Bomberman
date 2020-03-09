using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Object sceneToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
