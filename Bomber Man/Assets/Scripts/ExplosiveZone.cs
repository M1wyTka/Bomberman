using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveZone : MonoBehaviour
{
    public GameObject bomb;

    public float firstSpawnTime = 1f;
    public float repeatTime = 4f; 

    private void Start()
    {
        InvokeRepeating("SpawnBomb", firstSpawnTime, repeatTime);
    }

    private void SpawnBomb() 
    {
        GameObject spawnedBomb = Instantiate(bomb, transform.position, Quaternion.identity) as GameObject;
        spawnedBomb.SetActive(true);
    }
}
