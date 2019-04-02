using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour {


	GameObject Player;

	GameObject UI;
	GameObject DirectionsMenu;

	GameObject StartPos;

	GameObject Line;

	void Awake()
	{
		Player = GameObject.Find("Player");
		UI = GameObject.Find("Menus");
		DirectionsMenu = GameObject.Find("DirectionsMenu");
		StartPos = GameObject.Find ("GPSstartpos(Clone)");
	}
	void Update () 
	{
		Line = GameObject.Find("direction waypoint entity");
		if(Vector3.Distance(transform.position, Player.transform.position) < 3)
		{
			UI.SetActive(true);
			Destroy(Line);
			Destroy(StartPos);
			DirectionsMenu.SetActive(true);
			for(int i = 0; i < GameObject.FindGameObjectsWithTag("UI").Length; i++)
			{
				GameObject.FindGameObjectsWithTag("UI")[i].SetActive(false);
			}
			Destroy(gameObject);
		}
	}
}
