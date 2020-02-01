using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenu : MonoBehaviour
{
    private bool isPaused = false;

    private Vector3 initialTouch;
    private Vector3 currentTouch;

    private Transform mapCamera;

    private void Start()
    {
        mapCamera = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0);
    }

    public bool isGamePaused()
    {
        return isPaused;
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void Update()
    {
        if (isPaused && Input.touchCount > 0)
        {
            mapCamera.position -= (Vector3)Input.GetTouch(0).deltaPosition;
        }
    }
}
