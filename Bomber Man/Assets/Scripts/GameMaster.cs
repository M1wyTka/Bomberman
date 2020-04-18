using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance = null;

    public bool isPaused = false;

    public GameObject EndGameScreen;

    public Object mainMenuScene;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void LoseGame()
    {
        EndGameScreen.SetActive(true);
        Invoke("PauseGame", 2f);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.Confirm);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UnPauseGame();
    }

    public void GoToMainMenu()
    {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.Confirm);
        SceneManager.LoadScene(mainMenuScene.name);
        UnPauseGame();
    }
}
