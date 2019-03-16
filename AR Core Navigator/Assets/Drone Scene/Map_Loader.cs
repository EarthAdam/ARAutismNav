using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Loader : MonoBehaviour {

	public Camera cam;

	void Update () 
	{
		if(GameObject.Find("Player(Clone)"))
			{
			cam.enabled = true;
			transform.position = new Vector3(GameObject.Find("Player(Clone)").transform.position.x, 300, GameObject.Find("Player(Clone)").transform.position.z);
			}
	}
}
