using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maxwell : MonoBehaviour
{
	public Animator animator;
	public Rigidbody2D body;
	public Vector2 velocity;
	[SerializeField]
	public Vector2 target;
	
	bool walking = false;
	public float walkSpeed = 2.5f;
	
    void Start()
    {
        //animator.SetTrigger("IdleUp");
    }

    void Update()
    {
        
    }
	
	void FixedUpdate()
    {
		velocity = (target - (Vector2)body.transform.position).normalized;
        if(walking)
		{
			if (body.transform.position.y < -7.0f)
			{
				idle2();
			}
			else
			{
				body.MovePosition(body.position + velocity * walkSpeed * Time.fixedDeltaTime);
			}
		}
    }
	
	public void walkDown()
	{
		animator.SetTrigger("WalkDown");
		walking = true;
	}
	
	public void idle1()
	{
		animator.SetTrigger("Idle1");
	}
	
	public void idle2()
	{
		animator.SetTrigger("Idle2");
	}
}
