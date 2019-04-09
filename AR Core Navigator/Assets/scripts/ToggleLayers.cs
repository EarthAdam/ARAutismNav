using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLayers : MonoBehaviour {


    public GameObject[] BusRoutes;
    public GameObject[] Bikes;

    bool BusClick = true;
    bool BikeClick = true;
    public void OnclickBus()
    {
        BusClick = !BusClick;

    }

    public void OnclickBikes()
    {
        BikeClick = !BikeClick;
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
