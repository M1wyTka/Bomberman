using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DumbEnemyV2 : DumbEnemy
{
    [SerializeField] private Transform[] route = null;
    private Vector3[] milestones;

    protected override void Start()
    {
        milestones = new Vector3[route.Length];

        for(int i = 0; i < route.Length; i++)
        {
            milestones[i] = route[i].position;
        }

        if ((route != null) && (route.Length > 0))
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
