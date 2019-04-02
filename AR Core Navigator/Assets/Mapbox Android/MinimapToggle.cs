using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapToggle : MonoBehaviour {

	public Camera cam;
	public GameObject Minimap;

	public void ToggleOn()
	{
		cam.cullingMask = ~1 << 9;
		Minimap.SetActive(true);
	}

	public void ToggleOff()
	{
		cam.cullingMask = 1 << 9;
		Minimap.SetActive(false);
	}

}
