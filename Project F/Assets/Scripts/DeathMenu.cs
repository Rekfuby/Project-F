using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
	public GameObject deathMenuUI;
	
    void Start()
    {
        
    }

    void Update()
    {
        
    }
	
	public void ActivateDeathMenu()
	{
		deathMenuUI.SetActive(true);
		
	}
	
	public void ResetLevel()
	{
		Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
	}
	
	public void LoadMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
