using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
    public bool isPlayerBomb = true;

    public float timer = 3f;
    public int explosionDistance = 1;

    private PlayerAbilities playerAbils;

    private float startTime;

    private MapManager mapManager;

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
        if (isPlayerBomb)
            playerAbils = FindObjectOfType<PlayerAbilities>();
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - startTime > timer)
        {
            Explode();
        }
    }

    private void Explode()
    {
        mapManager.Explode(transform.position, explosionDistance);
        if(isPlayerBomb)
            playerAbils.BombExploded();
        Destroy(gameObject);
    }

    public void ReduceBombTimer(int reduction)
    {
        timer -= reduction;
        if (timer < 1)
            timer = 1;
    }

    public void IncreaseDistance(int increase)
    {
        explosionDistance += increase;
    }

}
