using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OpenAddLocationMenu : MonoBehaviour, IPointerEnterHandler
 {

	public GameObject Menu;
	public GameObject LocMenu;

	public void Onclick()
	{
		LocMenu.SetActive (true);
		Menu.SetActive(false);
	}

     // When highlighted with mouse.
     public void OnPointerEnter(PointerEventData eventData)
     {
		if(Input.GetAxis("Vive Trigger L") == 1)
		{
        	Onclick();
		}
     }
}
