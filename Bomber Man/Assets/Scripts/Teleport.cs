using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform outPlace;

    private List<Collider2D> collisions;

    private void Start()
    {
        collisions = new List<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collisions.Add(collision);
            collision.transform.GetComponent<PlayerController>().isMovable = false;
            Invoke("GoThrough", 0.3f);
        }

        if (collision.CompareTag("Enemy"))
        {
            collisions.Add(collision);
            Invoke("GoThrough", 0.3f);
        }
    }

    private void GoThrough()
    { 
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.Teleportation);
        foreach (Collider2D col in collisions)
        {
            col.transform.position = outPlace.position;
            if (col.CompareTag("Player"))
                col.transform.GetComponent<PlayerController>().isMovable = true;
        }
        collisions.Clear();
    }
}
