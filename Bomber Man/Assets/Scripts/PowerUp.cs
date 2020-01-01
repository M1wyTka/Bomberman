using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    [HideInInspector]
    public string[] PowerUpNames = new string[] {"Gotta Go Fast", "No Limits", "Blast Time" };

    [HideInInspector]
    public int arrayIdx = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Instantiate(pickupEffect, transform.position, transform.rotation);
            if (GivePowerUp(other, PowerUpNames[arrayIdx], GetComponent<SpriteRenderer>().sprite))
            {
                Destroy(gameObject);
            }
        }
    }

    private bool GivePowerUp(Collider2D player, string powUp, Sprite powUpSprite)
    {
        return player.GetComponent<PlayerAbilities>().PickUpPowerUp(powUp, powUpSprite);
    }

}
