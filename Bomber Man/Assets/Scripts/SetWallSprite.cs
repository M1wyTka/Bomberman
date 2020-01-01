using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWallSprite : MonoBehaviour
{

    public Sprite[] wallSprite;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform grandChild in child.transform)
            {
                grandChild.GetComponent<SpriteRenderer>().sprite = wallSprite[Random.Range(0, wallSprite.Length)] ;
            }
        }
    }
}
