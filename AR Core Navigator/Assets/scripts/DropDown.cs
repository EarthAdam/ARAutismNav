using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Examples;

[RequireComponent(typeof(Dropdown))]
public class DropDown : MonoBehaviour
{
    Dropdown myDropdown;

    public ForwardGeocodeUserInput Start;
    public ForwardGeocodeUserInput End;

    void Awake()
    {
        Start.HandleUserInput("Bethel Villiage Club House");
        End.HandleUserInput("Reynoldsburg Park Ride");
    }

    
    public void DropdownValueChanged(Dropdown change)
    {
        //Debug.Log("selected: "+change.value);
        switch(change.value)
        {
            case 0:
                Start.HandleUserInput("Bethel Villiage Club House");
                End.HandleUserInput("Reynoldsburg Park Ride");
                break;
            case 1:
                Start.HandleUserInput("Sharon Heights Columbus");
                End.HandleUserInput("1499 Hanson Street, Ohio 43068");
                break;
            case 2:
                Start.HandleUserInput("3077 Bembridge Road, Columbus");
                End.HandleUserInput("1638 Stringtown Rd SW");
                break;
        }
    }
}
