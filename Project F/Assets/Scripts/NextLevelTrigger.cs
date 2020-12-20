using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public AudioSource OpenAudio;
	public bool canProceed;
	
    void Start()
    {
       canProceed = false;
    }

    void Update()
    {
        OpenAudio = GetComponent<AudioSource>();
    }
	
	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.gameObject.tag == "Player" && canProceed) 
		{
			SceneManager.LoadScene("StartingLabs");
            OpenAudio.Play();
        }

	}
}
