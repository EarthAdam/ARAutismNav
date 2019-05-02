using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class MoveWithSlider : MonoBehaviour
{
    public List<GameObject> Targets;

    public GameObject[] TargetsList;
    private float m_Speed;
    public Slider SliderDis;
    
    void Start()
    {
        m_Speed = 10.0f;
    }

    void Update()
    {
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("POIMarker").Length; i++)
        {
            if (!Targets.Contains(GameObject.FindGameObjectsWithTag("POIMarker")[i]))
            {
                Targets.Add(GameObject.FindGameObjectsWithTag("POIMarker")[i]);
            }
        }

        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Building").Length; i++)
        {
            if (!Targets.Contains(GameObject.FindGameObjectsWithTag("Building")[i]))
            {
                Targets.Add(GameObject.FindGameObjectsWithTag("Building")[i]);
            }
        }

        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Bus Route").Length; i++)
        {
            if (!Targets.Contains(GameObject.FindGameObjectsWithTag("Bus Route")[i]))
            {
                Targets.Add(GameObject.FindGameObjectsWithTag("Bus Route")[i]);
            }
        }

        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Taxi").Length; i++)
        {
            if (!Targets.Contains(GameObject.FindGameObjectsWithTag("Taxi")[i]))
            {
                Targets.Add(GameObject.FindGameObjectsWithTag("Taxi")[i]);
            }
        }

        TargetsList = Targets.ToArray();
    }
    
    public void OnChange()
    {
        for(int i = 0; i < TargetsList.Length; i++)
        {
            if(TargetsList[i].gameObject.tag == "POIMarker" || TargetsList[i].gameObject.tag == "Building")
            {
                TargetsList[i].transform.position = new Vector3(TargetsList[i].transform.position.x, SliderDis.value, TargetsList[i].transform.position.z);
            }
            if(TargetsList[i].gameObject.tag == "Bus Route")
            {
                TargetsList[i].transform.position = new Vector3(TargetsList[i].transform.position.x, SliderDis.value*5.5f, TargetsList[i].transform.position.z);
            }
            if(TargetsList[i].gameObject.tag == "Taxi")
            {
                TargetsList[i].transform.position = new Vector3(TargetsList[i].transform.position.x, SliderDis.value*10, TargetsList[i].transform.position.z);
            }
            if (TargetsList[i].transform.position.y <= 0)
            {
                TargetsList[i].transform.position = new Vector3(TargetsList[i].transform.position.x, 0.1f, TargetsList[i].transform.position.z);
            }
          //  if (TargetsList[i].transform.position.y >= 20)
            {
          //      Targets[i].transform.position = new Vector3(TargetsList[i].transform.position.x, 0.1f, TargetsList[i].transform.position.z);
            }
        }
    }
    
    public void reset()
    {
        //SliderDis.value = 0;
    }
}