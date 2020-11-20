using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    public Animator animator;
    public Vector2 playerVelocity;

    float horizontal;
    float vertical;
    float isRunning;

    public float walkSpeed = 2.5f;
    public float runSpeed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        isRunning = Input.GetAxisRaw("Run");

        if (horizontal != 0 || vertical != 0)
        {
            playerVelocity = new Vector2(horizontal, vertical);
            playerVelocity = playerVelocity.normalized;
            if (isRunning > 0)
            {
                playerVelocity *= runSpeed;
            }
            else 
            {
                playerVelocity *= walkSpeed;
            }
        }
        else
        {
            playerVelocity = Vector2.zero;
        }

        body.velocity = playerVelocity;
        //Debug.Log(body.velocity);


    }

    void FixedUpdate()
    {
        
    }
}
