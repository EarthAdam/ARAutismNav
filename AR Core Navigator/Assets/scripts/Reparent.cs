using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reparent : MonoBehaviour
{
    public ColorPOI CP;
    //[HideInInspector]
    public GameObject Child;
    void Update()
    {
        if(Child != null & CP.GGC != null)
        {
            Child.transform.SetParent(CP.GGC);
        }
        foreach (Transform child in gameObject.transform)
        {
            foreach (Transform grandchild in child.transform)
            {
                if (null == grandchild)
                {
                    continue;
                }
                else
                {
                    foreach (Transform greatgrandchild in grandchild.transform)
                    {
                        if (null == greatgrandchild)
                        {
                            continue;
                        }
                        else
                        {
                            foreach (Transform thisisstupid in greatgrandchild.transform)
                            {
                                if (null == thisisstupid)
                                {
                                    continue;                              
                                }
                                else
                                {
                                    //Debug.Log(thisisstupid);
                                    Child = thisisstupid.gameObject;
                                    thisisstupid.DetachChildren();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
