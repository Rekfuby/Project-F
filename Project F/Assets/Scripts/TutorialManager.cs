using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	private GameObject playerObj = null;
	private GameObject pistol = null;
	private GameObject keycard = null;
	private GameObject continueButton = null;
	
	public bool basicMovement;
	public bool advancedMovement;
	public bool itemInteraction;
	public bool shooting;
	
	public bool passedBasicMovement;
	public bool passedAdvancedMovement;
	public bool passedItemInteraction;
	public bool passedShooting;
	
	bool up = false, down = false, left = false, right = false;
	
	
    void Start()
    {
		findItems();
		hideItems();
		
		if (playerObj == null)
		{
			playerObj = GameObject.Find("Player");
			
		}
		
		basicMovement = false;
		advancedMovement = false;
		itemInteraction = false;
		shooting = false;
		
		passedBasicMovement = false;
		passedAdvancedMovement = false;
		passedItemInteraction = false;
		passedShooting = false;
    }

    void Update()
    {
		findContinueButton();
		
        if (basicMovement)
		{
			if (Input.GetKeyDown("w"))
			{
				up = true;
			}
			if (Input.GetKeyDown("a"))
			{
				left = true;
			}
			if (Input.GetKeyDown("s"))
			{
				down = true;
			}
			if (Input.GetKeyDown("d"))
			{
				right = true;
			}
			if (up && down && left && right)
			{
				passedBasicMovement = true;
				enableContinueButton();
				basicMovement = false;
			}
		}
		
		if (advancedMovement)
		{
			if (Input.GetKeyDown("left shift"))
			{
				passedAdvancedMovement = true;
				enableContinueButton();
				advancedMovement = false;
			}
		}
		
		if (itemInteraction)
		{
			if (playerObj.GetComponent<PlayerController>().hasWeapon)
			{
				passedItemInteraction = true;
				enableContinueButton();
				itemInteraction = false;
			}
		}
		
		if (shooting)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				passedShooting = true;
				enableContinueButton();
				shooting = false;
				playerObj.GetComponent<PlayerController>().hasWeapon = false;
			}
		}
    }
	
	public void findItems()
	{
        if (pistol == null)
		{
			pistol = GameObject.Find("Pistol");
		}
		if (keycard == null)
		{
			keycard = GameObject.Find("Keycard");
		}
	}
	
	public void hideItems()
	{
        pistol.SetActive(false);
		keycard.SetActive(false);
	}
	
	public void SpawnPistol()
	{
		pistol.SetActive(true);
	}
	
	public void SpawnKeycard()
	{
		keycard.SetActive(true);
	}
	
	public void findContinueButton()
	{
		if (continueButton == null)
			{
				continueButton = GameObject.Find("Continue");
			}
	}
	
	public void disableContinueButton()
	{
		continueButton.SetActive(false);
	}
	
	public void enableContinueButton()
	{
		continueButton.SetActive(true);
	}
}
