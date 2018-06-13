using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemovePoint : MonoBehaviour {

	public Text InputText;

	private GameObject point;

	public void Onclick()
	{
		if (InputText.text != "") 
		{
			point = GameObject.Find (InputText.text + "(Clone)");
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
}
