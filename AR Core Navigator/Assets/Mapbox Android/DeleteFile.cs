using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DeleteFile : MonoBehaviour {
	public InputField FileNameText;
	public Text DebugText;
	public void Delete() 
	{
		string path = Application.persistentDataPath+@"/"+FileNameText.text+".txt";
		
		if (!File.Exists(path))
		{
			DebugText.text = FileNameText.text + " path does not exist"; //Debug.Log( "no " + fileName + " file exists" );
		}
		else
		{
			DebugText.text = FileNameText.text + " path deleted"; //Debug.Log( fileName + " file exists, deleting..." );
			File.Delete(path);
		}
	}

	public void DeleteAll()
	{
		string path = Application.persistentDataPath;

		if (Directory.Exists(path)) 
		{
			Directory.Delete(path, true); 
		}
 		//Directory.CreateDirectory(path);
	}
}
