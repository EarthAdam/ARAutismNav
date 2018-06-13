using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAddLocationMenu : MonoBehaviour {

	public GameObject Menu;
	public GameObject LocMenu;

	public void Onclick()
	{
		LocMenu.SetActive (true);
		Menu.SetActive(false);
	}

}
