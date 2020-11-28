using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    private GameObject playerObj = null;
	//int maxAnchorCount = 1;
	Vector2 anchorPoint;
	
	
	bool inFuture = false;
	
    void Start()
    {
        if (playerObj == null)
		{
			playerObj = GameObject.Find("Player");
		}
    }

    void Update()
    {
        
    }
	
	void travelForth()
	{
		anchorPoint = (Vector2)playerObj.transform.position;
		playerObj.transform.position = new Vector2(playerObj.transform.position.x - 100f, playerObj.transform.position.y);
		playerObj.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
	}
	
	void travelBack()
	{
		playerObj.transform.position = new Vector2(playerObj.transform.position.x + 100f, playerObj.transform.position.y);;
		playerObj.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
	}
	
	public void travel()
	{
		if (!inFuture)
		{
			inFuture = true;
			travelForth();
		}
		else
		{
			inFuture = false;
			travelBack();
		}
	}
}
