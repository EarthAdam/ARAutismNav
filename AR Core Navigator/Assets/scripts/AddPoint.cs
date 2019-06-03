using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AddPoint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler  {

	public GameObject Point;
	public GameObject PointText;
	public InputField IP;

	public Text VRtext;
	public GameObject Player;
	private float timer;
	
	private bool timeron;

	void Update()
	{
		//Debug.Log(timer);
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
			if (!GameObject.Find (IP.text + "(Clone)")) 
			{
				Point.GetComponentInChildren<TextMesh> ().text = IP.text;
				Point.name = IP.text;
				Instantiate (Point, new Vector3 (Player.transform.position.x, 5, Player.transform.position.z), new Quaternion (0, 0, 0, 0));
			} 
			else 
			{
				Debug.LogError ("DUPLICATE NAMES ARE FORBIDDEN");
			}
		} 
		else 
		{
			Debug.LogError ("EMPTY NAMES ARE FORBIDDEN");
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
