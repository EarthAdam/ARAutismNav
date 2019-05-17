using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayEnabled : MonoBehaviour
{
    public GameObject otherobj;
    void Update()
    {
        if(gameObject.transform.childCount > 11)
        {
            otherobj.SetActive(true);
            this.enabled = false;
        }
    }
}
