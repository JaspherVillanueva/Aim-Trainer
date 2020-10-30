using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is used to control timer selection for each game.
// The timer selected by the user through the GUI is passed into the main game.
// Thus setting the limit for how long each mode lasts.

// Aim Trainer - 2020 - Jaspher Villanueva

public class TimerDropdown : MonoBehaviour
{
    private List<string> time = new List<string>() { "1 Minute", "2 Minutes", "5 Minutes" };

    public Dropdown timerdropDown;
    
    private int dropdownValue = 0;
    
    public static int timer = 60;

    void Start()
    {
        timerdropDown = GetComponent<Dropdown>();
        
        timerdropDown.onValueChanged.AddListener(delegate
        {
            checkTimeSelected(timerdropDown);
        });

        addTime(time);
    }

    // This function adds the list variables into the timer dropdown.
    void addTime(List<string> time)
    {
        timerdropDown.AddOptions(time);
    }

    // This function checks for the dropdown value (0-2) and changes the value of time 
    // everytime the user selects a different value from the dropdown.
    void checkTimeSelected(Dropdown timeSelected)
    {
        dropdownValue = timeSelected.value;

        if (dropdownValue == 0) 
        {
            setTimer(60);  
        }
        else if (dropdownValue == 1)
        {
            setTimer(120);
        }
        else if (dropdownValue == 2)
        {
            setTimer(300);
        }

    }

    void setTimer(int newTime)
    {
        timer = newTime;
    }

}
