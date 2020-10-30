using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDropdown : MonoBehaviour
{
    List<string> time = new List<string>() { "1 Minute", "2 Minutes", "5 Minutes" };

    public Dropdown timerdropDown;
    public int dropdownValue;
    public static int timer = 60;

    void Start()
    {
        timerdropDown = GetComponent<Dropdown>();    //get the value from the dropdown menu
        timerdropDown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(timerdropDown);
        });
        timerdropDown.AddOptions(time);
        Debug.Log("Starting Dropdown Time: "
            + timer);
        Debug.Log("Starting Dropdown Value: "
            + timerdropDown.value);
    }

    void DropdownValueChanged(Dropdown change) //set the amount of time with the value from the dropdown
    {
        dropdownValue = change.value;

        if (dropdownValue == 0) 
        {
            timer = 60;  
        }
        else if (dropdownValue == 1)
        {
            timer = 120;
        }
        else if (dropdownValue == 2)
        {
            timer = 300;
        }
        Debug.Log(timer);
        Debug.Log(timerdropDown.value);
    }
}
