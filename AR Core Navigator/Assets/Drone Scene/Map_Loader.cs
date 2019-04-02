using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Loader : MonoBehaviour {

	public Camera cam;

	void Update () 
	{
		if(GameObject.Find("Player"))
			{
			cam.enabled = true;
			transform.position = new Vector3(GameObject.Find("Player").transform.position.x, 300, GameObject.Find("Player").transform.position.z);
			}
	}
}
