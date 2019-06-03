using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class RemovePoint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public InputField IP;
	public Text VRtext;

	private GameObject point;

	private float timer;
	
	private bool timeron;

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
	}

	public void Onclick()
	{
		if (IP.text != "") 
		{
			point = GameObject.Find (IP.text + "(Clone)");
			if (point != null) 
			{
				Destroy (point);
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
