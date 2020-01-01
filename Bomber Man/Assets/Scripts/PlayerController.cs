using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    private Joystick joystick;
    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movement;
    private Vector2 SideForces = new Vector2(0, 0);
    private List<Vector2> Forces = new List<Vector2>();


    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal >= 0.2f || joystick.Horizontal <= -0.2f || joystick.Vertical >= 0.2f || joystick.Vertical <= -0.2f)
        {
            movement = new Vector2(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed);
        }
        else
        {
            movement = new Vector2(0, 0);
        }
        UpdateAnimation(movement);
    }

    public void AdjustMovement(Vector2 adjustment)
    {
        if (Forces.Contains(adjustment))
            Forces.Add(adjustment);
        else if (Forces.Contains(-adjustment))
        {
            Forces.Remove(-adjustment);
            if(!Forces.Contains(-adjustment))
                SideForces += adjustment;
        }
        else {
            Forces.Add(adjustment);
            SideForces += adjustment;
        }
    }

    public void IncreaseSpeed(float increase)
    {
        moveSpeed += increase;
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement + SideForces);
    }

    private void UpdateAnimation(Vector2 move)
    {
        animator.SetFloat("Speed", move.sqrMagnitude);
        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y); 
    }

    private void MoveCharacter(Vector2 move)
    {
        rb.MovePosition((Vector2)transform.position + move*Time.deltaTime);
    }
}
