using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationGPS : MonoBehaviour {

	public Text InputText;
	public Text OutputText;
	public GameObject player;

	private GameObject point;
	private bool active;

	public void Onclick()
	{
		if (InputText.text != "") 
		{
			point = GameObject.Find (InputText.text + "(Clone)");
			if (point != null) 
			{
				active = true;
			} 
			else 
			{
				Debug.LogError ("NO WAYPOINT FOUND");
			}
		} 
		else 
		{
			Debug.LogError ("NO TEXT ENTERED");
		}
	}

	private void Update()
	{
		if (active) 
		{
			OutputText.text = (Mathf.Round(Vector3.Distance (player.transform.position, point.transform.position)).ToString() + "M");
		}
	}
}
