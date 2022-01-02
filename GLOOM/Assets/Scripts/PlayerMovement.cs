using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    //Variables
    private const float walkSpeed = 1.5f;
    private const float runSpeed = 3f;
    private AudioSource footstep;

    private float moveSpeed = walkSpeed;
    public Rigidbody2D Rigidbody2D;
    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        footstep = GetComponent<AudioSource>();
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
            // Shift + tecla de moviment permet correr
            moveSpeed = runSpeed;
        }
        else
        {
            // Per defecte la velocitat del personatge es la de caminar
            moveSpeed = walkSpeed;
        }
    }

    void FixedUpdate()
    {
        //Movement
        Rigidbody2D.MovePosition(Rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Footstep()
    {
        footstep.Play();
    }
}
