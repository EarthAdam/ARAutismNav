using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WarningSystem : MonoBehaviour {



	public Text Debug;
	public bool Safe;
	public bool Unsafe;
	public bool Dangerous;
	public InputField InputText;

	public InputField PhoneName;

	public InputField TextSendMessagePhoneNumberField;

	AndroidJavaObject currentActivity;



	public void ManualCall () 
	{
		//AndroidJavaObject jo = new AndroidJavaObject("android.permission.CALL_PHONE");
		 
		Application.OpenURL("tel://");
		Debug.text = "Phone Call Function Proc";
	}

	public void Texttest()
	{
        Send("Goofus");
	}

	public void autocalltest()
	{
		//PlayerPrefs.GetString(PhoneName.text)
		string phoneNum = "tel:  "+PlayerPrefs.GetString("PhoneNumber");

		//For accessing static strings(ACTION_CALL) from android.content.Intent
		AndroidJavaClass intentStaticClass = new AndroidJavaClass("android.content.Intent");
		string actionCall = intentStaticClass.GetStatic<string>("ACTION_CALL");
		//ACTION_CALL

		//Create Uri
		AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
		AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", phoneNum);

		//Pass ACTION_CALL and Uri.parse to the intent
		AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", actionCall, uriObject);

		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

		try
		{
			unityActivity.Call("startActivity", intent);
		}
		catch
		{
			Debug.text = "Failed to call";
		}


	}
	 
	public void Send(string phone)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            RunAndroidUiThread();
        }
    }

    void RunAndroidUiThread()
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(SendProcess));
    }

    void SendProcess()
    {
        Debug.text = "Running on UI thread";
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        
        // SMS Information
        //PlayerPrefs.GetString(TextSendMessagePhoneNumberField.text);
		//InputText.text;
        //string phone = "6144413041";
		string phone = PlayerPrefs.GetString("PhoneNumber");
        string text = "I seem to be a little Off track";
        string alert;

        try
        {
            // SMS Manager

            AndroidJavaClass SMSManagerClass = new AndroidJavaClass("android.telephony.SmsManager");
            AndroidJavaObject SMSManagerObject = SMSManagerClass.CallStatic<AndroidJavaObject>("getDefault");
            SMSManagerObject.Call("sendTextMessage", phone, null, text, null, null);

            alert = "Message sent successfully.";
        }
        catch (System.Exception e)
        {
            Debug.text = "Error : " + e.StackTrace.ToString();

            alert = "Error has been Occurred. Fail to send message.";
        }

        // Show Toast

        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", alert);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }


	public void SetDistance()
	{
		PlayerPrefs.SetFloat("PathDistance", float.Parse(InputText.text));
		string path = Application.persistentDataPath+@"/DistanceDocuments.txt";
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine("Max distance allowed from path: " + InputText.text + " feet");
		writer.Close();
	}
}
