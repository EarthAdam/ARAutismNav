using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VRButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private float timer;

	private bool timeron;

	public MoveWithSlider MS;

	public ToggleLayers TL;

	public bool Add;

	public bool Sub;

	public bool map1;

	public bool map2;

	public bool map3;

	public GameObject XR;

	void Update()
	{
		//Debug.Log(timer);
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
		if(Add)
		{
			MS.OnClickPlus();
		}
		if(Sub)
		{
			MS.OnClickMinus();
		}
		if(map1)
        {
            TL.OnClickMap1();
        }
        if(map2)
        {
            TL.OnClickMap2();
        }
        if(map3)
        {
            TL.OnClickMap3();
        }
		if(gameObject.name == "VRToggle")
		{
			XR.SetActive(!XR.activeInHierarchy);
		}
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
		MS.OnExit();
	}
}
