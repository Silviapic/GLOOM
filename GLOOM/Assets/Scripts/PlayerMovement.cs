using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float walkSpeed = 1.5f;
    private const float runSpeed = 3f;

    private float moveSpeed = walkSpeed;
    public Rigidbody2D Rigidbody2D;
    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.LeftShift)) {
            // Set current speed to run if shift is down
            moveSpeed = runSpeed;
        }
        else
        {
            // Otherwise set current speed to walking speed
            moveSpeed = walkSpeed;
        }
    }



    void FixedUpdate()
    {
        //Movement
        Rigidbody2D.MovePosition(Rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
