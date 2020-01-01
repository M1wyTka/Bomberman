using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform outPlace;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.Teleportation);
            collision.transform.position = outPlace.position;
        }
    }
}
