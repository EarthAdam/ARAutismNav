using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIdisable : MonoBehaviour {

	void Update () 
	{
		for(int x = 0; x < GameObject.FindGameObjectsWithTag("POI").Length; x++) 
		{
       		GameObject PoI = GameObject.FindGameObjectsWithTag("POI")[x];
      		PoI.GetComponent<MeshRenderer>().enabled = false;
		}
	}
}