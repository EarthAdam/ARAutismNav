using UnityEngine;
//using UnityEditor;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;
using Mapbox.Unity;
using Mapbox.Json;
using Mapbox.Directions;
using Mapbox.Utils;
using Mapbox.Utils.JsonConverters;
using Mapbox.Geocoding;
using Mapbox.Unity.Map;

public class FileToMap : MonoBehaviour {

	public Text DEbug;
	public string filedata;
	public AbstractMap _map;

	public string[] linesInFile;

	public float transformlat;

	public float transformlong;

	public Material cubemat;

	private bool On;
	private Vector3 lastcubepos;

	public InputField InputText;

	private GameObject objToSpawn;

	public Texture tex;

	public void readTextFileLines() 
	{
		string path = Application.persistentDataPath+@"/"+InputText.text+".txt";
        StreamReader reader = new StreamReader(path);
        filedata = reader.ReadToEnd();

		if(GameObject.Find(InputText.text + " path"))
		{
			Destroy(GameObject.Find(InputText.text + " path"));
		}

		objToSpawn = new GameObject(InputText.text + " path");

		LineRenderer L = objToSpawn.gameObject.AddComponent(typeof (LineRenderer)) as LineRenderer;
		TexShift TX = objToSpawn.gameObject.AddComponent(typeof (TexShift)) as TexShift;
		TX.tex = tex;

		objToSpawn.tag = "LoadedSavedPath";



		linesInFile = filedata.Split('\n');
		L.positionCount = 0;
		On = true;
		DEbug.text = linesInFile.Length.ToString();
	
		for(int i = 0; i < linesInFile.Length; i++)
		{
			transformlat = float.Parse(linesInFile[i].Split(' ')[0]);
			transformlong = float.Parse(linesInFile[i].Split(' ')[1]);
			if(transformlat == 0 & transformlong == 0)
			{
				L.SetPosition (i, lastcubepos);
				break;
			}
			else
			{
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.parent = _map.transform;
				cube.gameObject.name = "SavedWaypoint"+i;
				cube.transform.parent = objToSpawn.transform;
				objToSpawn.transform.parent = _map.gameObject.transform;		
				cube.transform.localScale = new Vector3(PlayerPrefs.GetFloat("PathDistance"),10,PlayerPrefs.GetFloat("PathDistance"));
				if(PlayerPrefs.GetFloat("PathDistance") < 10)
				{
					cube.transform.localScale = new Vector3(Mathf.RoundToInt(10*_map.gameObject.transform.localScale.x),100,Mathf.RoundToInt(10*_map.gameObject.transform.localScale.z));
				}
				if(PlayerPrefs.GetFloat("PathDistance") > 100)
				{
					cube.transform.localScale = new Vector3(100,10,100);
				}
				cube.transform.position = _map.GeoToWorldPosition(new Vector2d(transformlat, transformlong), false);
				cube.gameObject.tag = "path";
				cube.GetComponent<Renderer>().material = cubemat;
				L.positionCount += 1;
				Vector3 cubepos = new Vector3(cube.transform.position.x, 0, cube.transform.position.z);
				lastcubepos = cubepos;
				L.SetPosition (i, cubepos);
			}
		}
	}
}

