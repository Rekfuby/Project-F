using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastDoor : MonoBehaviour
{
	public bool opened = false;
	Vector2 playerOffPos;
	BoxCollider2D collider2d;
	public bool locked = true;
	
	private GameObject playerObj = null;
	public Animator animator;
	
	void Start()
    {
        if (playerObj == null)
		{
			playerObj = GameObject.Find("Player");
		}
		collider2d = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
		playerOffPos = (Vector2)playerObj.transform.position;
		if (Input.GetButtonDown("Use") && playerCloseToObject())
		{
			if (!locked)
			{
					if (!opened)
				{
					open();
				}
				else
				{
					close();
				}
			}
			else
			{
				// locked door audio here
			}
			
		}
    }
	
	public bool playerCloseToObject()
	{
		if (Vector2.Distance(transform.position, playerOffPos) < 2.0f)
		{
			return true;
		}
		else 
		{
			return false;
		}
		
	}
	
	public void open()
	{
		animator.SetTrigger("Open");
		opened = true;
		animator.SetBool("isOpened", true);
		collider2d.enabled = false;
	}
	
	public void close()
	{
		animator.SetTrigger("Close");
		opened = false;
		animator.SetBool("isOpened", false);
		collider2d.enabled = true;
	}
	
}
