using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffects : MonoBehaviour
{
    public static void ApplyEffect(GameObject player, string effect, MonoBehaviour instance)
    {
        switch (effect)
        {   
            case "Gotta Go Fast": instance.StartCoroutine(GoFast(player)); break;
            case "No Limits": instance.StartCoroutine(NoLimits(player)); break;
            case "Blast Time": break;
            default: break;
        }
    }

    public static IEnumerator NoLimits(GameObject player)
    {
        player.GetComponent<PlayerAbilities>().IncreaseBombAmount(100);
        yield return new WaitForSeconds(5);
        player.GetComponent<PlayerAbilities>().IncreaseBombAmount(-100);
    }

    public static IEnumerator GoFast(GameObject player)
    {
        player.GetComponent<PlayerController>().IncreaseSpeed(40);
        yield return new WaitForSeconds(5);
        player.GetComponent<PlayerController>().IncreaseSpeed(-40);
    }
}
