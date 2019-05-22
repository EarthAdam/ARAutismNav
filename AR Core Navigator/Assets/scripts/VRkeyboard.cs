using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class VRkeyboard : MonoBehaviour {

	public InputField input;
	public GameObject keyboard;
	public Text inputkeyboard;

	void Update () 
	{
		if (XRSettings.enabled) 
		{
			keyboard.SetActive (true);
			input.text = inputkeyboard.text;
		} 
		else 
		{
			keyboard.SetActive (false);
		}	
	}
}
