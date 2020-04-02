using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenu : MonoBehaviour
{
    private Vector3 initialTouch;
    private Vector3 currentTouch;

    private Transform mapCamera;

    private void Start()
    {
        mapCamera = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0);
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        GameMaster.Instance.UnPauseGame();
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        GameMaster.Instance.PauseGame();
    }

    private void Update()
    {
        if (GameMaster.Instance.isPaused && Input.touchCount > 0)
        {
            mapCamera.position -= (Vector3)Input.GetTouch(0).deltaPosition;
        }
    }
}
