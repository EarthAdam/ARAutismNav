using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLayers : MonoBehaviour {

    public GameObject BusRoutes;

    void Start()
    {
        BusRoutes = GameObject.Find("Bus Routes");        
    }

    public void OnclickBus()
    {
        BusRoutes.SetActive(!BusRoutes.activeInHierarchy);
    }

    public void OnclickBikes()
    {
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("POImarker").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("POImarker")[i].SetActive(!GameObject.FindGameObjectsWithTag("POImarker")[i].activeInHierarchy);
        }
    }

}
