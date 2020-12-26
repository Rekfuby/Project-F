using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
	private GameObject playerObj = null;
	private GameObject nextLevelTrigger = null;
	Vector2 playerOffPos;
	
    void Start()
    {
        if (playerObj == null)
		{
			playerObj = GameObject.Find("Player");
			
		}
		if (nextLevelTrigger == null)
		{
			nextLevelTrigger = GameObject.Find("NextLevelTrigger");
		}
    }

    void Update()
    {
        playerOffPos = (Vector2)playerObj.transform.position;
		
		if (Input.GetButtonDown("Use") && playerCloseToObject())
		{
			if (name == "Pistol")
			{
				playerObj.GetComponent<PlayerController>().hasWeapon = true;
				Destroy(this.gameObject);
			}
			if (name == "Keycard")
			{
				nextLevelTrigger.GetComponent<NextLevelTrigger>().canProceed = true;
				Destroy(this.gameObject);
			}
			if (name == "Chronos")
			{
				playerObj.GetComponent<PlayerController>().canTravel = true;
				Destroy(this.gameObject);
			}
		}
    }
	
	public bool playerCloseToObject()
	{
		if (Vector2.Distance(transform.position, playerOffPos) < 1.8f)
		{
			return true;
		}
		else 
		{
			return false;
		}
		
	}
}
