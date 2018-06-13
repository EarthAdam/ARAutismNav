using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLayers : MonoBehaviour {

    private GameObject start;
    private GameObject end;
    private GameObject traffic;
    private GameObject bike;
    private GameObject ped;
    private GameObject grid;
    // Use this for initialization
    void Start()
    {
        start = GameObject.Find("Start");
        start.SetActive(false);
        end = GameObject.Find("End");
        end.SetActive(false);
        traffic = GameObject.Find("Mobility Map");
        traffic.SetActive(false);
        bike = GameObject.Find("Bicycle Map");
        bike.SetActive(false);
        ped = GameObject.Find("Pedestrian Map");
        ped.SetActive(false);
        grid = GameObject.Find("Power Map");
        grid.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            start.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            end.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            traffic.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            bike.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            ped.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            grid.SetActive(true);
        }
    }
}
