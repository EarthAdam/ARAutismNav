using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRToggle : MonoBehaviour
{
    public GameObject UnityXR;
    public GameObject LeftMove, RightMove;
    void Update()
    {
        if(GameObject.Find(UnityXR.gameObject.name))
        {
            GetComponent<VRTK_UICanvas>().enabled = true;
            LeftMove.SetActive(false);
            RightMove.SetActive(false);
        }
        else
        {
            GetComponent<VRTK_UICanvas>().enabled = false;
            LeftMove.SetActive(true);
            RightMove.SetActive(true);
        }
    }
}
