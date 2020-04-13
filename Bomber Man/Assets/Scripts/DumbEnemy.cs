using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemy : MonoBehaviour
{
    public Transform position_1, position_2;

    public float speed;

    private protected Vector3 nextPos;

    protected virtual void Start()
    {
        nextPos = position_1.position;
    }

    protected virtual void Move()
    {
        if (transform.position == nextPos)
        {
            if (nextPos == position_1.position)
                nextPos = position_2.position;
            else nextPos = position_1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Move();
    }
}
