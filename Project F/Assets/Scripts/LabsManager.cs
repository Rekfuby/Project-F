using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabsManager : MonoBehaviour
{
	private int doorNum = 12;
	private GameObject[] bds = new GameObject[12];
	
	
    void Start()
    {
        for(int i = 0; i < doorNum; i++)
		{
			bds[i] = GameObject.Find(string.Format("BlastDoor{0}", i + 1));
			Debug.Log(bds[i]);
		}
		bds[0].GetComponent<BlastDoor>().locked = false;
		bds[1].GetComponent<BlastDoor>().locked = false;
		bds[6].GetComponent<BlastDoor>().locked = false;
		bds[8].GetComponent<BlastDoor>().locked = false;
		bds[9].GetComponent<BlastDoor>().locked = false;
    }

    
    void Update()
    {
        
    }
}
