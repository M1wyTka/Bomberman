using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1f;

    private float compareSpeed = 10f;

    private Animator animator;
    private Vector2 pushDirection;

    private void Start()
    {
        pushDirection = (transform.GetChild(0).position - transform.position).normalized;
        animator = transform.GetComponent<Animator>();
        animator.speed = Speed / compareSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerController>().AdjustMovement(Speed * pushDirection);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerController>().AdjustMovement(-Speed * pushDirection);
        }
        
    }

}
