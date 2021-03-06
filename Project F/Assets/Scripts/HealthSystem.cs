﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
	private GameObject playerObj = null;
	
	public DeathMenu deathMenu;
    public int health;
    public int maxHealth;

	public int activeAnchors;
	public int maxAnchors;
	
    public Image[] lives;

    public Sprite fullLive;
    public Sprite emptyLive;
    public GameObject Live;
    public GameObject Panel;

    public float step = 0.25f;
	
	public static bool dead;

    void Start()
    {
		if (playerObj == null)
		{
			playerObj = GameObject.Find("Player");
		}
		activeAnchors = 0;
		dead = false;
    }

    void Update()
    {
		if (health <= 0)
		{
			if (activeAnchors <= 0)
			{
				Dead();
			}
			else
			{
				toLastAnchor();
			}
			
		}
		
        if (maxHealth <= 4)
        {
            ChangeMaxHealth(maxHealth = 4);
        }
        else if (maxHealth >= 5 && maxHealth <= 10)
        {
            ChangeMaxHealth(maxHealth);
        }
        else {
            ChangeMaxHealth(maxHealth = 10);
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLive;
            }
            if (i < maxHealth)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    }

    void ChangeMaxHealth(int maxHealth) 
	{
        this.maxHealth = maxHealth;
        Live.transform.localScale = new Vector3((1 + (maxHealth - 4) * step), Live.transform.localScale.y, Live.transform.localScale.z);
        //Panel.transform.position = new Vector3(maxHealth,
        //                                        Panel.transform.position.y,
        //                                        Panel.transform.position.z);
    }
	
	void Dead() 
	{
		Debug.Log("Dead");
		deathMenu.ActivateDeathMenu();
		dead = true;
		playerObj.GetComponent<Animator>().SetTrigger("Death");
	}
    
	void toLastAnchor()
	{
		
	}
}
