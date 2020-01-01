using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Transform position_1, position_2;

    public float speed;

    private Vector3 nextPos;

    void Start()
    {
        nextPos = position_1.position;
    }

    void FixedUpdate()
    {
        if (transform.position == nextPos) {
            if (nextPos == position_1.position)
                nextPos = position_2.position;
            else nextPos = position_1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        AstarPath.active.UpdateGraphs(gameObject.GetComponent<BoxCollider2D>().bounds);
    }
}
