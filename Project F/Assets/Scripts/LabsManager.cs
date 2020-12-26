using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabsManager : MonoBehaviour
{
	private int doorNum = 12;
	private GameObject[] bds = new GameObject[12];
	private GameObject[] sds = new GameObject[2];
	
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
		sds[0] = GameObject.Find("SlideDoor1");
		sds[1] = GameObject.Find("SlideDoor2");
    }

    
    void Update()
    {
        
    }
	
	public void unlockSlideDoor()
	{
		sds[0].GetComponent<BlastDoor>().open();
	}
	
	public void lockSlideDoor()
	{
		sds[0].GetComponent<BlastDoor>().close();
	}
	
	public bool opened()
	{
		if (sds[0].GetComponent<BlastDoor>().opened)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
