using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;

    public Object sceneToLoad;

    public Slider progessSlider;

    public GameObject menu;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
            Destroy(gameObject);

    }

    public void LoadGameLvl()
    {
        progessSlider.gameObject.SetActive(true);
        menu.SetActive(false);
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad.name);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            
            progessSlider.value = progress;

            yield return null;
        }
    }
}
