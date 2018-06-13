using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busTrip : MonoBehaviour {
    private GameObject start;
    private GameObject end;
    // Use this for initialization
    void Start () {
        start = GameObject.Find("Start");
        start.SetActive(false);
        end = GameObject.Find("End");
        end.SetActive(false);
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
    }
}
