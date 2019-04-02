using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSavedPath : MonoBehaviour 
{

	public GameObject DirectionsPrefabStart;
	public GameObject DirectionsPrefabEnd;

	public InputField IP;
	public void LoadPath()
	{
		if(GameObject.Find("GPSstartpos(Clone)"))
		{
			Destroy(GameObject.Find("GPSstartpos(Clone)"));
		}
		Instantiate(DirectionsPrefabStart);
		if(GameObject.Find("GPSendpos(Clone)"))
		{
			Destroy(GameObject.Find("GPSendpos(Clone)"));
		}
		Instantiate(DirectionsPrefabEnd);
		GameObject.Find("GPSendpos(Clone)").transform.position = new Vector3(PlayerPrefs.GetFloat(IP.text +" endX"), PlayerPrefs.GetFloat(IP.text +" endY"), PlayerPrefs.GetFloat(IP.text +" endZ"));
		GameObject.Find("GPSstartpos(Clone)").transform.position = new Vector3(PlayerPrefs.GetFloat(IP.text +" startX"), PlayerPrefs.GetFloat(IP.text +" startY"), PlayerPrefs.GetFloat(IP.text +" startZ"));
	}

}
