using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRToggle : MonoBehaviour
{
    public GameObject UnityXR;
    public GameObject LeftMove, RightMove, Plus, Minus;
    void Update()
    {
        if(GameObject.Find(UnityXR.gameObject.name))
        {
            GetComponent<VRTK_UICanvas>().enabled = true;
            LeftMove.SetActive(false);
            RightMove.SetActive(false);
            Plus.SetActive(true);
            Minus.SetActive(true);
            for(int i = 0; i < GameObject.FindGameObjectsWithTag("Keyboard").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("Keyboard")[i].SetActive(true);
            }
        }
        else
        {
            GetComponent<VRTK_UICanvas>().enabled = false;
            LeftMove.SetActive(true);
            RightMove.SetActive(true);
            Plus.SetActive(false);
            Minus.SetActive(false);
            for(int i = 0; i < GameObject.FindGameObjectsWithTag("Keyboard").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("Keyboard")[i].SetActive(false);
            }
        }
    }
}
