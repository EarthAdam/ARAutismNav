using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPOI : MonoBehaviour
{
    public Color myColor;

    void Update()
    {
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
                                else if ( thisisstupid.gameObject.GetComponentInChildren<SpriteRenderer>().color == myColor)
                                {
                                    break;                              
                                }
                                else
                                {
                                    Debug.Log(thisisstupid.gameObject);
                                    thisisstupid.gameObject.GetComponentInChildren<SpriteRenderer>().color = myColor;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
