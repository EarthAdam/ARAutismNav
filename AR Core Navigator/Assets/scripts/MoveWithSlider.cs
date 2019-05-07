using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class MoveWithSlider : MonoBehaviour
{
   // public List<GameObject> Targets;

    public GameObject[] TargetsList;
    private float m_Speed;
    public Slider SliderDis;

    public ColorPOI Map1, Map2, Map3;

    private Color Save1, Save2, Save3;
    
    void Start()
    {
        m_Speed = 10.0f;
        Save1 = Map1.myColor;
        Save2 = Map2.myColor;
        Save3 = Map3.myColor;
    }

    void Update()
    {
        TargetsList = GameObject.FindGameObjectsWithTag("Map");
        if(SliderDis.value == 0)
        {
            Map1.myColor = Color.black;
            Map2.myColor = Color.black;
            Map3.myColor = Color.black;
        }
        else
        {
            Map1.myColor = Save1;
            Map2.myColor = Save2;
            Map3.myColor = Save3;
        }
    }
    
    public void OnChange()
    {
        for(int i = 0; i < TargetsList.Length; i++)
        {
            if(TargetsList[i].gameObject.name == "Map")
            {
                TargetsList[i].transform.position = new Vector3(TargetsList[i].transform.position.x, SliderDis.value*2, TargetsList[i].transform.position.z);
            }
            if(TargetsList[i].gameObject.name == "Map 2")
            {
                TargetsList[i].transform.position = new Vector3(TargetsList[i].transform.position.x, SliderDis.value*5.5f, TargetsList[i].transform.position.z);
            }
            if(TargetsList[i].gameObject.name == "Map 3")
            {
                TargetsList[i].transform.position = new Vector3(TargetsList[i].transform.position.x, SliderDis.value*10, TargetsList[i].transform.position.z);
            }
            if (TargetsList[i].transform.position.y <= 0)
            {
                TargetsList[i].transform.position = new Vector3(TargetsList[i].transform.position.x, 0.1f, TargetsList[i].transform.position.z);
            }
        }
    }
    
    public void reset()
    {
        //SliderDis.value = 0;
    }
}