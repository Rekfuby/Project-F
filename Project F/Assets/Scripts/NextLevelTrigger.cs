﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			SceneManager.LoadScene("StartingLabs");
		}
	}
}
