

using UnityEngine;
using UnityEngine.UI;


public class PathSave : MonoBehaviour
{

	public InputField IP;
	public void CreatePrefab()
	{
		PlayerPrefs.SetFloat(IP.text +" endX", GameObject.Find("GPSendpos(Clone)").transform.position.x);
		PlayerPrefs.SetFloat(IP.text +" endY", GameObject.Find("GPSendpos(Clone)").transform.position.y);
		PlayerPrefs.SetFloat(IP.text +" endZ", GameObject.Find("GPSendpos(Clone)").transform.position.z);

		PlayerPrefs.SetFloat(IP.text +" startX", GameObject.Find("GPSstartpos(Clone)").transform.position.x);
		PlayerPrefs.SetFloat(IP.text +" startY", GameObject.Find("GPSstartpos(Clone)").transform.position.y);
		PlayerPrefs.SetFloat(IP.text +" startZ", GameObject.Find("GPSstartpos(Clone)").transform.position.z);
	}
}

