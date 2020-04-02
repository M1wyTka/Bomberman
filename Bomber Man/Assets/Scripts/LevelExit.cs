using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelExit : MonoBehaviour
{
    public Object mainMenuScene;

    public float transactionTime;

    [SerializeField]
    private Image foregroundImage;

    private IEnumerator transfer;

    private void Awake()
    {
        transfer = GoToMainMenu();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartTransfer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopTransfer();
        }
    }

    private void StartTransfer()
    {
        StartCoroutine(transfer);
    }

    private void StopTransfer()
    {
        StopCoroutine(transfer); // for some reason also makes transfer = null
        transfer = GoToMainMenu();
        foregroundImage.fillAmount = 0f;
    }

    private IEnumerator GoToMainMenu() {
        float elapsed = 0f;
        while(elapsed < transactionTime) 
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = elapsed / transactionTime;
            yield return null;
        }

        GameMaster.Instance.LoseGame();
    }
}
