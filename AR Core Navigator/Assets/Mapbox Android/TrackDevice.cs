using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity;
using System;
using Mapbox.Json;
using Mapbox.Directions;
using Mapbox.Utils;
using Mapbox.Utils.JsonConverters;
using Mapbox.Geocoding;
using Mapbox.Unity.Map;
public class TrackDevice : MonoBehaviour {

	public Text Debug;
    
    public AbstractMap _map;
    public bool DebugOn;
    public GameObject Player;

    private bool Running;

    private float Latit;
    private float Longit;
	void Start()
	{
		StartCoroutine(StartLoc());
	}

    void Update()
    {
        if(Running)
        {
            Player.transform.position = _map.GeoToWorldPosition(new Vector2d(Latit,Longit), true);
            StartCoroutine(StartLoc());
            Running = false;
        }
    }
	IEnumerator StartLoc()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.text = "Timed out on GPS position";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            if(DebugOn)
            {
                Debug.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
            }
            Latit = Input.location.lastData.latitude;
            Longit = Input.location.lastData.longitude;
            Running = true;
        }

        // Stop service if there is no need to query location updates continuously
        //Input.location.Stop();
    }
}
