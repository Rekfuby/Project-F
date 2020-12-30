using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	protected float health = 5f;
	protected float maxHealth = 5f;
	[SerializeField]
	protected float moveSpeed = 3f;
    protected bool hit = false;

    public void damaged(float damage)
	{
		health = health - damage;
        hit = true;
        if (health <= 0) 
		{
			Dead();
		}
	}
	
	public void Dead()
	{
		Destroy(this.gameObject);
	}
	
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
