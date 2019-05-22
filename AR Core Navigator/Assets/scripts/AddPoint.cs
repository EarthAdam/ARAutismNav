using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPoint : MonoBehaviour {

	public GameObject Point;
	public GameObject PointText;
	public Text InputText;
	public GameObject Player;


	public void Onclick()
	{
		if (InputText.text != "") 
		{
			if (!GameObject.Find (InputText.text + "(Clone)")) 
			{
				Point.GetComponentInChildren<TextMesh> ().text = InputText.text;
				Point.name = InputText.text;
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
