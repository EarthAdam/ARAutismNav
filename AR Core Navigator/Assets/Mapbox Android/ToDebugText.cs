using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToDebugText : MonoBehaviour {

	public Text DB;
	void Start () 
	{
		DB = GameObject.Find("Debug").GetComponent<Text>();
		DB.text = transform.position.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
