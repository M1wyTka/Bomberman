using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnPoint : MonoBehaviour
{
    public static float delay = 0.02f;

    public int enterDirection = 0;

    public bool spawned = false;

    void Start()
    {
        Invoke("SpawnRoom", delay);
        delay += 0.02f;
    }

    private void SpawnRoom()
    {
        if (!spawned)
        {
            spawned = true;
            GameObject.Find("Level Generator").transform.GetComponent<LevelGenerator>().SpawnRoom(transform.position, enterDirection);
            AstarPath.active.UpdateGraphs(GameObject.Find("Tilemap_Walls").GetComponent<TilemapCollider2D>().bounds);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Room Center"))
        {
            //Debug.Log(collision.name);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Spawn Point") && !collision.transform.GetComponent<SpawnPoint>().spawned && !spawned)
        {
            spawned = true;
            LevelGenerator lvlGen = GameObject.Find("Level Generator").transform.GetComponent<LevelGenerator>();
            lvlGen.SpawnRoom(transform.position, lvlGen.deadEnd);
            Destroy(gameObject);
        }
    }
}
