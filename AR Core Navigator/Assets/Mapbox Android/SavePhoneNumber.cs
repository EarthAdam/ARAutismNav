using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePhoneNumber : MonoBehaviour {

	public InputField InputText;

	public InputField PhoneName;
	void Start() 
	{
		
	}
	

	public void OnClick() 
	{
		PlayerPrefs.SetString("PhoneNumber", InputText.text);
	}
	public void DeleteSingle()
	{
		PlayerPrefs.DeleteKey("PhoneNumber");
	}
}
