using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

	bool dialogueStarted = false;
	
    void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player" && !dialogueStarted) 
		{
			dialogueStarted = true;
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		}
	}
}
