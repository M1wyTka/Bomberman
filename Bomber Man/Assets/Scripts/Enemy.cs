using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    private GameObject target;

    private bool vunerable = true;

    public void Start()
    {
        if(transform.GetComponent<AIDestinationSetter>())
            transform.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerStats>().TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (vunerable) {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
            StartCoroutine(BecomeInvunerable(1));
        }
    }

    private IEnumerator BecomeInvunerable(float time)
    {
        vunerable = false;
        for (int i = 0; i <= 10; i++)
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(time / 20);
            transform.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(time / 20);
        }
        vunerable = true;
    }

    private void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
