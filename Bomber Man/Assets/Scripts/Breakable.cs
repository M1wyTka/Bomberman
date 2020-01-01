using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public int health = 1;

    public GameObject breakEffect;
    public GameObject[] upgrades;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Collapse();
    }

    private void Collapse()
    {
        // Instantiate(breakEffect, transform.position, Quarternion.identity);
        Destroy(gameObject);
        DropUpgrade();
        AstarPath.active.UpdateGraphs(gameObject.GetComponent<BoxCollider2D>().bounds);
        //AstarPath.active.Scan();
    }

    private void DropUpgrade()
    {
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(upgrades[Random.Range(0, upgrades.Length)], transform.position, Quaternion.identity);
        }
    }

}
