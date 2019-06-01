using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AddPoint : MonoBehaviour {

	public GameObject Point;
	public GameObject PointText;
	public InputField IP;

	public Text VRtext;
	public GameObject Player;

	void Update()
	{
		if(GameObject.Find("UnityXR"))
		{
			IP.text = VRtext.text;
			gameObject.GetComponent<EventTrigger>().enabled = true;
		}
		else
		{
			gameObject.GetComponent<EventTrigger>().enabled = false;
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
}
