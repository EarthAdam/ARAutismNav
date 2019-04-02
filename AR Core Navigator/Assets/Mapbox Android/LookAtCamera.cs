using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

	public string stringtxt;
	void Start()
	{
		stringtxt = GetComponentInChildren<TextMesh>().text;
	}

	void Update()
	{
		transform.localPosition = new Vector3 (transform.localPosition.x, 3, transform.localPosition.z);
		if(GameObject.Find("ARCore Device"))
		{
			transform.LookAt(GameObject.Find("ARCore Device").transform);
			transform.localScale = new Vector3(-.5f, transform.localScale.y, transform.localScale.z);
			if(Vector3.Distance(transform.position, GameObject.Find("ARCore Device").transform.position) < 15)
			{
				GetComponentInChildren<TextMesh>().text = "";
			}			
			else
			{
				GetComponentInChildren<TextMesh>().text = stringtxt;
			}	
		}
		else
		{
			transform.rotation = new Quaternion(45,0,0,45);
			transform.localScale = new Vector3(.5f, transform.localScale.y, transform.localScale.z);
		}
	}
}
