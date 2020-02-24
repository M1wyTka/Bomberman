using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTracker : MonoBehaviour
{
    public GameObject UpgradeIcon = null;

    private int upgradeCount = 0;

    private void Start()
    {
        upgradeCount = transform.childCount;
    }

    public void UpgradeGone() 
    {
        upgradeCount--;
        if(upgradeCount <= 0)
            Destroy(UpgradeIcon);
    }
}
