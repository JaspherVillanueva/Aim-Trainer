using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDropdown : MonoBehaviour
{
    List<string> time = new List<string>() { "1 Minute", "5 Minutes", "10 Minutes" };

    public Dropdown timerdropDown;
    public int dropdownValue;
    public static int timer = 60;

    void Start()
    {
        timerdropDown = GetComponent<Dropdown>();
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

    void DropdownValueChanged(Dropdown change)
    {
        dropdownValue = change.value;

        if (dropdownValue == 0) 
        {
            timer = 60;  
        }
        else if (dropdownValue == 1)
        {
            timer = 300;
        }
        else if (dropdownValue == 2)
        {
            timer = 600;
        }

        Debug.Log(timer);
        Debug.Log(timerdropDown.value);
    }

}
