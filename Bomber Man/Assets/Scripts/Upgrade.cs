using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrade : MonoBehaviour
{
    public GameObject pickupEffect;

    [HideInInspector]
    public string[] Upgrades = new string[] { "Range Upgrade", "Speed Upgrade", "Amount Upgrade", "Timer Upgrade", "Health Upgrade" };
    [HideInInspector]
    public int arrayIdx = 0;

    private UpgradeTracker upgradeTracker = null;

    private void Start()
    {
        upgradeTracker = transform.GetComponentInParent<UpgradeTracker>();  
    }   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            ApplyEffect(other);
            if (upgradeTracker != null)
                upgradeTracker.UpgradeGone();
        }
    }

    public void ApplyEffect(Collider2D player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.Upgrade);
        switch (Upgrades[arrayIdx])
        {
            case ("Range Upgrade"): IncreaseRange(player); break;
            case ("Speed Upgrade"): IncreaseSpeed(player); break;
            case ("Amount Upgrade"): IncreaseAmount(player); break;
            case ("Timer Upgrade"): ReduceTimer(player); break;
            case ("Health Upgrade"): IncreaseHealth(player); break;
            default: Debug.Log("default state in upgrade"); break;
        }
    }

    private void ReduceTimer(Collider2D player)
    {
        player.GetComponent<PlayerAbilities>().bomb.GetComponent<Bomb>().ReduceBombTimer(1);
    }

    private void IncreaseRange(Collider2D player)
    {
        player.GetComponent<PlayerAbilities>().bomb.GetComponent<Bomb>().IncreaseDistance(1);
    }

    private void IncreaseAmount(Collider2D player)
    {
        player.GetComponent<PlayerAbilities>().IncreaseBombAmount(1);
    }

    private void IncreaseSpeed(Collider2D player)
    {
        player.GetComponent<PlayerController>().IncreaseSpeed(5);
    }

    private void IncreaseHealth(Collider2D player)
    {
        player.GetComponent<PlayerStats>().IncreaseHealth(1);
    }

}
