using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLayers : MonoBehaviour
{
    
    public GameObject[] BusRoutes;
    public GameObject[] Bikes;
    
    public GameObject Map;

    public GameObject Map2;

    public GameObject Map3;

    bool BusClick = true;
    bool BikeClick = true;

    private float timer;

	private bool timeron;
    public void OnclickBus()
    {
        BusClick = !BusClick;
    }

    public void OnclickBikes()
    {
        BikeClick = !BikeClick;
    }

    public void OnClickMap1()
    {
        Map.SetActive(!Map.activeInHierarchy);
    }

    public void OnClickMap2()
    {
        Map.GetComponent<DelayEnabled>().enabled = !Map.GetComponent<DelayEnabled>().enabled;
        Map2.SetActive(!Map2.activeInHierarchy);
    }

    public void OnClickMap3()
    {
        Map2.GetComponent<DelayEnabled>().enabled = !Map2.GetComponent<DelayEnabled>().enabled;
        Map3.SetActive(!Map3.activeInHierarchy);
    }

    void Update()
    {
        if(BusClick == false)
        {
            for(int i = 0; i < BusRoutes.Length; i++)
            {
                BusRoutes[i].SetActive(false);
            }
        }
        else
        {
            for(int i = 0; i < BusRoutes.Length; i++)
            {
                BusRoutes[i].SetActive(true);
            }
        }

        if(BikeClick == false)
        {
            for(int i = 0; i < Bikes.Length; i++)
            {
                Bikes[i].SetActive(false);
            }
        }
        else
        {
            for(int i = 0; i < Bikes.Length; i++)
            {
                Bikes[i].SetActive(true);
            }
        }

        if(BusClick == true)
        {
            BusRoutes = GameObject.FindGameObjectsWithTag("Bus Route");
        }
        if(BikeClick == true)
        {
            Bikes = GameObject.FindGameObjectsWithTag("POIMarker");
        }
    }
}
