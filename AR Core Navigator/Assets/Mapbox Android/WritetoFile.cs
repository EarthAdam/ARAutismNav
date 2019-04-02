using UnityEngine;
//using UnityEditor;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System;

public class WritetoFile: MonoBehaviour
{
	public string lastpos;

    public float lat;
    public float Long;

	public Text Debug;

    public InputField FileNameText;

    void Start()
    {
        lastpos = "";
    }
    void Update()
    {   
        string path = Application.persistentDataPath+@"/"+FileNameText.text+".txt";
        //Debug.text = path;
        
        //Write some text to the test.txt file
        
        StreamWriter writer = new StreamWriter(path, true);
		if(lastpos != "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude & Input.location.lastData.latitude != 0 & Input.location.lastData.longitude != 0)
		{
			writer.WriteLine(Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
            //writer.WriteLine(lat + " " + Long);
			lastpos = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
            //lastpos = "Location: " + lat + " " + Long;
		}
        
        
        writer.Close();

        //Re-import the file to update the reference in the editor
        //AssetDatabase.ImportAsset(path); 
        //TextAsset asset = Resources.Load("test");

        //Print the text from the file
        //Debug.Log(asset.text);

        //Read the text from directly from the test.txt file
        //StreamReader reader = new StreamReader(path); 
        //Debug.text = reader.ReadToEnd();
        //reader.Close();
        
        /* 
        TextWriter tw = new StreamWriter(Application.persistentDataPath+@"/file.sav");
        tw.Write("strToSave");
        tw.Close();
        */
        
    }

    /*
    public IEnumerator Upload()
    {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes(lastpos);
        UnityWebRequest www = UnityWebRequest.Put("http://www.my-server.com/upload", myData);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) 
        {
            Debug.text = www.error;
        }
        else {
            Debug.text = "Upload complete!";
        }
    }
    */
 
  
}
