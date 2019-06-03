using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRToggle : MonoBehaviour
{
    public GameObject UnityXR;
    public GameObject LeftMove, RightMove, Plus, Minus;

    private GameObject[] Keyboard;

    void Start()
    {
        Keyboard = GameObject.FindGameObjectsWithTag("Keyboard");
    }
    void Update()
    {
        if(GameObject.Find(UnityXR.gameObject.name))
        {
            GetComponent<VRTK_UICanvas>().enabled = true;
            LeftMove.SetActive(false);
            RightMove.SetActive(false);
            Plus.SetActive(true);
            Minus.SetActive(true);
            for(int i = 0; i < Keyboard.Length; i++)
            {
                Keyboard[i].SetActive(true);
            }
        }
        else
        {
            GetComponent<VRTK_UICanvas>().enabled = false;
            LeftMove.SetActive(true);
            RightMove.SetActive(true);
            Plus.SetActive(false);
            Minus.SetActive(false);
            for(int i = 0; i < Keyboard.Length; i++)
            {
                Keyboard[i].SetActive(false);
            }
        }
    }
}
