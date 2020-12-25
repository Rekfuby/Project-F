using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoicker : BaseEnemy
{
    private GameObject playerObj = null;
	Vector2 playerOffPos;
	Rigidbody2D body;
	
	private Vector2 startingPos;
	private Vector2 movement;
	
	public Animator animator;
	
	float targetRange = 5f;
	float attackRange = 1.3f;
	
	float preAttackTime = 0.66f;
	float attackCD = 1f;
	float attackTimer = 0;
	bool foundTarget = false;
	bool attacking = false;
	bool attackOnCD = false;
	
	
    void Start()
    {
		body = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
		if (playerObj == null)
		{
			playerObj = GameObject.Find("Player");
		}
    }

    
    void Update()
    {
		playerOffPos = (Vector2)playerObj.transform.position;
		if (playerOffPos.x < transform.position.x)
		{
			animator.SetBool("Mirror", false);
		}
		else
		{
			animator.SetBool("Mirror", true);
		}
		
		if (!attacking)
		{
			if (foundTarget)
			{
				if (Vector2.Distance(transform.position, playerOffPos) < attackRange)
				{
					attackTarget();
					animator.SetBool("Attacking", true);
				}
				else
				{
					Vector2 direction = playerOffPos - (Vector2)transform.position;
					float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
					direction.Normalize();
					movement = direction;
					chaseCharacter(movement);
				}
			}
			else
			{
				findTarget();
			}
		}
		else
		{
			if (attackTimer > 0)
			{
				attackTimer -= Time.deltaTime;
			}
			else
			{
				if (!attackOnCD)
				{
					if (Vector2.Distance(transform.position, playerOffPos) < attackRange)
					{
						playerObj.GetComponent<HealthSystem>().health -= 1;
					}
					attackOnCD = true;
				}
				else
				{
					attackTimer -= Time.deltaTime;
					if (attackTimer < 0 - attackCD)
					{
						attacking = false;
						attackOnCD = false;
						animator.SetBool("Attacking", false);
					}
				}
			}
		}
    }
	
	private void findTarget()
	{
		if (Vector2.Distance(transform.position, playerOffPos) < targetRange)
		{
			Debug.Log("Chasing player");
			foundTarget = true;
		}
	}
	
	void chaseCharacter(Vector2 direction)
	{
		if (Vector2.Distance(transform.position, playerOffPos) >= targetRange + 2f)
		{
			foundTarget = false;
		}
		else {
			body.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
		}
	}
	
	void attackTarget()
	{
		attacking = true;
		attackTimer = preAttackTime;
	}
}
