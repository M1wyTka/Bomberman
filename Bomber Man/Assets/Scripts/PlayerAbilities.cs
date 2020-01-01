using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject bomb;

    private string powerUp = null;

    public int numberOfBombs = 1;
    private int bombsPresent = 0;

    private Button powerUpButton;
    private Text bombLabel;

    public void Start()
    {
        powerUpButton = GameObject.Find("PowerUpButton").GetComponent<Button>();
        bombLabel = GameObject.Find("BombCountText").GetComponent<Text>();
        UpdateBombCounter();
    }

    public void DropBomb()
    {
        if (bombsPresent < numberOfBombs)
        {
            bombsPresent++;
            UpdateBombCounter();

            GameObject summonedBomb = Instantiate(bomb, calculateSpawnVector(), Quaternion.identity) as GameObject;
            summonedBomb.gameObject.SetActive(true);
        }
    }

    public void IncreaseBombAmount(int increase)
    {
        numberOfBombs += increase;
        UpdateBombCounter();
    }

    public void BombExploded()
    {
        bombsPresent--;
        UpdateBombCounter();
    }

    public void UsePowerUp()
    {
        if (powerUp != null)
        {
            PowerUpEffects.ApplyEffect(gameObject, powerUp, this);
            powerUp = null;
            powerUpButton.GetComponent<Image>().sprite = null;
        }
    }

    public bool PickUpPowerUp(string powUp, Sprite powUpSprite)
    {
        if (powerUp == null) {
            powerUp = powUp;
            powerUpButton.GetComponent<Image>().sprite = powUpSprite;
            return true;
        }
        return false;
    }

    private void UpdateBombCounter()
    {
        bombLabel.text = "Bombs " + (numberOfBombs - bombsPresent) + "/" + numberOfBombs;
    }

    private Vector3 calculateSpawnVector()
    {
        int roundedX = Mathf.RoundToInt(transform.position.x);
        if (roundedX >= 0)
        {
            if ((roundedX / 5) % 2 == 0)
                roundedX = roundedX / 5 * 5 + 5;
            else roundedX = roundedX / 5 * 5;
        }
        else
        {
            if ((roundedX / 5) % 2 == -1)
                roundedX = roundedX / 5 * 5;
            else roundedX = roundedX / 5 * 5 - 5;
        }

        int roundedY = Mathf.RoundToInt(transform.position.y);
        if (roundedY >= 0)
        {
            if ((roundedY / 5) % 2 == 0)
                roundedY = roundedY / 5 * 5 + 5;
            else roundedY = roundedY / 5 * 5;
        }
        else
        {
            if ((roundedY / 5) % 2 == -1)
                roundedY = roundedY / 5 * 5;
            else roundedY = roundedY / 5 * 5 - 5;
        }

        return new Vector3(roundedX, roundedY, 0);
    }
}
