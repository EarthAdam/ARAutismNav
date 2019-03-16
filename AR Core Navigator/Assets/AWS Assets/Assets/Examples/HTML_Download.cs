using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;


public class HTML_Download : MonoBehaviour {

    public Text Results;
    public InputField DownloadFileName;

    public void onClick()
    {
        StartCoroutine(Check());
    }
    
    private IEnumerator Check()
    {
        WWW w = new WWW("https://s3.console.aws.amazon.com/s3/buckets/arcorenavigator/"+DownloadFileName.text);
        yield return w;
        if (w.error != null)
        {
            Results.text = "Error .. " +w.error;
        }
        else
        {
            Results.text = w.text;
            //Results.text = "Download Complete!";
            OnChange(w);
        }        
    }

    public void OnChange(WWW w)
    {
        string path = Application.persistentDataPath+@"/"+DownloadFileName.text;
        if (File.Exists(path))
		{
			File.Delete(path);
		}
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(Results.text);
        writer.Close();
    }
}
