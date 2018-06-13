using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMainMenu : MonoBehaviour {

	public GameObject Menu;
	public GameObject LocMenu;

	public void Onclick()
	{
		Menu.SetActive (true);
		LocMenu.SetActive(false);
	}

}
