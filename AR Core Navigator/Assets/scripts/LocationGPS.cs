using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class LocationGPS : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


	public InputField IP;
	public Text VRtext;
	public Text OutputText;
	public GameObject player;

	private GameObject point;
	private bool active;

	private float timer;
	
	private bool timeron;

	public void Onclick()
	{
		if (IP.text != "") 
		{
			point = GameObject.Find (IP.text + "(Clone)");
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
		if(timeron)
		{
			timer += .1f;
		}
		if(GameObject.Find("UnityXR") && timer >= 5)
		{
			Onclick();
		}
		if(GameObject.Find("UnityXR"))
		{
			IP.text = VRtext.text;
		}
		if (active) 
		{
			OutputText.text = (Mathf.Round(Vector3.Distance (player.transform.position, point.transform.position)).ToString() + "M");
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		timeron = true;
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		timeron = false;
		timer = 0;
	}
}
