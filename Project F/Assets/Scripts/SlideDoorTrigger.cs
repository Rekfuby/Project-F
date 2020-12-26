using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoorTrigger : MonoBehaviour
{
	private GameObject labs = null;
	LabsManager labscr;
	
    void Start()
    {
        if (labs == null)
		{
			labs = GameObject.Find("LabsManager");
			labscr = labs.GetComponent<LabsManager>();
		}
    }

    void Update()
    {
        
    }
	
	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.gameObject.tag == "Player" && labscr.opened()) 
		{
			labscr.lockSlideDoor();
        }

	}
}
