using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoicker : BaseEnemy
{
    private GameObject playerObj = null;
	Vector2 playerOffPos;
	Rigidbody2D body;
    AudioSource audioSrc;
    BulletController bullet;

    private Vector2 startingPos;
	private Vector2 movement;
	
	public Animator animator;
    public AudioClip[] clip;

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
        audioSrc = GetComponent<AudioSource>();
        audioSrc.playOnAwake = false;
        audioSrc.loop = false;
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
                    audioSrc.loop = false;
                    audioSrc.clip = clip[Random.Range(1,3)];
                    audioSrc.volume = Random.Range(0.5f, 4f);
                    audioSrc.Play();
                  
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
                if (!audioSrc.isPlaying)
                {
                    audioSrc.loop = true;
                    audioSrc.clip = clip[0];
                    audioSrc.volume = Random.Range(0.3f, 5f);
                    audioSrc.Play();
                }
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
        if (hit)
        {
            audioSrc.loop = false;
            audioSrc.clip = clip[Random.Range(3, 5)];
            audioSrc.volume = Random.Range(0.5f, 4f);
            audioSrc.Play();
            hit = false;
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
            if (!audioSrc.isPlaying)
            {
                audioSrc.loop = true;
                audioSrc.clip = clip[5];
                audioSrc.volume = Random.Range(0.8f, 2f);
                audioSrc.Play();
            }
            body.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime)); 
        }
	}
	
	void attackTarget()
	{
		attacking = true;
		attackTimer = preAttackTime;
	}
}
