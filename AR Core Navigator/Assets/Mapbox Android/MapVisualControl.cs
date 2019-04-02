using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapVisualControl : MonoBehaviour {


	public bool showroads;
	public bool showsidewalks;
	public bool showsidepaths;
	//public bool showlocationnames;
	public bool showbuildings;

	public bool showHazards;

	public bool ShowSavePath;

	public Material streets;
	public Material sidewalk;
	public Material buildings;
	public Material Hazard;
	public Shader Invis;

	void Update () 
	{ /* 
		if(!showlocationnames)
		{
			for(int x = 0; x < GameObject.FindGameObjectsWithTag("POI").Length; x++) 
			{
				GameObject PoI = GameObject.FindGameObjectsWithTag("POI")[x];
				PoI.GetComponent<MeshRenderer>().enabled = false;
			}
		}
		else
		{
			for(int x = 0; x < GameObject.FindGameObjectsWithTag("POI").Length; x++) 
			{
				GameObject PoI = GameObject.FindGameObjectsWithTag("POI")[x];
				PoI.GetComponent<MeshRenderer>().enabled = true;
			}
		}
		*/

		if(!showroads)
		{
			streets.shader = Invis;
		}
		else
		{
			streets.shader = Shader.Find("Standard");
		}

		if(!showsidewalks)
		{
			sidewalk.shader = Invis;
		}
		else
		{
			sidewalk.shader = Shader.Find("Standard");
		}

		if(!showbuildings)
		{
			buildings.shader = Invis;
		}
		else
		{
			buildings.shader = Shader.Find("PDT Shaders/TestGrid");
		}

		if(!showHazards)
		{
			Hazard.shader = Invis;
		}
		else
		{
			Hazard.shader = Shader.Find("Standard");
		}

		if(!ShowSavePath)
		{
			for(int x = 0; x < GameObject.FindGameObjectsWithTag("LoadedSavedPath").Length; x++) 
			{
				GameObject PoI = GameObject.FindGameObjectsWithTag("LoadedSavedPath")[x];
				PoI.GetComponent<LineRenderer>().enabled = false;
			}
		}
		else
		{
			for(int x = 0; x < GameObject.FindGameObjectsWithTag("LoadedSavedPath").Length; x++) 
			{
				GameObject PoI = GameObject.FindGameObjectsWithTag("LoadedSavedPath")[x];
				PoI.GetComponent<LineRenderer>().enabled = true;
			}
		}
	
	}

	public void ToggleSidewalks()
	{
		showsidewalks = !showsidewalks;
	}
	public void ToggleBuildings()
	{
		showbuildings = !showbuildings;
	}
	public void ToggleRoads()
	{
		showroads = !showroads;
	}
	public void ToggleHazards()
	{
		showHazards = !showHazards;
	}

	public void TogglePath()
	{
		ShowSavePath = !ShowSavePath;
	}

}
