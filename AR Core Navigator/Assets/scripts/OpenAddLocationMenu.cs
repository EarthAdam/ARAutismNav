using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OpenAddLocationMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
 {

	public GameObject Menu;
	public GameObject LocMenu;

	private float timer;

	private bool timeron;


	void Update()
	{
		if(timeron)
		{
			timer += .1f;
		}
		if(GameObject.Find("UnityXR") && timer >= 5)
		{
			Onclick();
		}
		
	}

	public void Onclick()
	{
		LocMenu.SetActive (true);
		Menu.SetActive(false);
		timeron = false;
		timer = 0;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		timeron = true;
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		timeron = false;
		timer = 0;
	}
}
