using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float blastTime = 1f;

    private void Start()
    {
        StartCoroutine(Blast());        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerStats>().TakeDamage(1);
        }
        else if (collision.CompareTag("Enemy") || collision.CompareTag("Smart Enemy"))
        {
            collision.transform.GetComponent<Enemy>().TakeDamage(1);
        }
    }

    private IEnumerator Blast()
    {
        yield return new WaitForSeconds(blastTime*0.1f);
        AstarPath.active.Scan();
        yield return new WaitForSeconds(blastTime * 0.9f);
        Destroy(gameObject);
    }
}
