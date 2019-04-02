using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCheck : MonoBehaviour {

	public GameObject Popup;
	public GameObject Popup2;
	public WarningSystem WS;

	void OnTriggerEnter(Collider other)
    {
			if(other.tag == "BadArea")
			{
				Popup2.SetActive(true);
				StartCoroutine(CallParent());
			}
			if (other.tag == "path")
			{
				Popup.SetActive(false);
				WS.Texttest();
			}
    }

	void OnTriggerExit(Collider other)
    {
			if(other.tag == "BadArea")
			{
			//	Popup2.SetActive(false);
				Popup.SetActive(false);
			}
			if (other.tag == "path")
			{
				Popup.SetActive(true);
			}
    }

	IEnumerator CallParent()
	{
		yield return new WaitForSeconds(5);
		WS.autocalltest();
	}
}
