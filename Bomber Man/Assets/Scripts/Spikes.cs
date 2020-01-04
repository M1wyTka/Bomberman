using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
        if(collision.CompareTag("Enemy") || collision.CompareTag("Smart Enemy"))
            collision.GetComponent<Enemy>().TakeDamage(damage);
    }
}
