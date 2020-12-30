using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoickerTrigger : MonoBehaviour
{
	public Dialogue HoickerDialogue;

	bool dialogueStarted = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && !dialogueStarted)
		{
			dialogueStarted = true;
			FindObjectOfType<MaxwellDialogueManager>().StartHoickerDialogue(HoickerDialogue);
		}
	}
}
