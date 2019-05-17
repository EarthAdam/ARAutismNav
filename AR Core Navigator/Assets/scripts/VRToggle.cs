using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRToggle : MonoBehaviour
{
    public GameObject VRCamera;

    void Update()
    {
        if(UnityEngine.XR.XRDevice.isPresent & !GameObject.Find("[CameraRig](Clone)") )
        {
            //Debug.Log("VR Device active");
            Instantiate(VRCamera, transform.position, transform.rotation, transform);
        }
        else
        {
            //Debug.Log("VR Device Inactive");
        }
    }
}
