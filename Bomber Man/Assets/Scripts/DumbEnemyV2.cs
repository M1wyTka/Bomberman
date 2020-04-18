using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DumbEnemyV2 : DumbEnemy
{
    [SerializeField] private GameObject route = null;
    private Vector3[] milestones;

    protected override void Start()
    {
        int routeCount = route.transform.childCount;
        milestones = new Vector3[routeCount];
        
        for(int i = 0; i < routeCount; i++)
        {
            milestones[i] = route.transform.GetChild(i).position;
        }

        if ((route != null) && (routeCount > 0))
        {
            nextPos = milestones[0];
        }
        else
        {
            Debug.Log("Dumb Enemy V2 is missing milestones");
        }
    }

    protected override void Move()
    {
        if (transform.position == nextPos)
        {
            int nextPosIndex = Array.IndexOf(milestones, nextPos) + 1;

            if (nextPosIndex == milestones.Length)
                nextPos = milestones[0];
            else
                nextPos = milestones[nextPosIndex];
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
