using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is used to control map selection for mode 1.
// The map selected by the user through the GUI is passed into the scene controller
// Thus checking which map is selected for the that map scene to be loaded.

// Aim Trainer - 2020 - Jaspher Villanueva

public class MapDropdown : MonoBehaviour
{
    private List<string> maps = new List<string>() { "The Ring", "Stair Master"};

    public Dropdown mapdropDown;

    public static int mapValue = 0;

    void Start()
    {
        mapdropDown = GetComponent<Dropdown>();

        mapValue = mapdropDown.value;

        mapdropDown.onValueChanged.AddListener(delegate
        {
            checkMapSelected(mapdropDown);
        });

        addMaps(maps);
    }

    // This function adds the list variables into the map dropdown.
    void addMaps(List <string> maps)
    {
        mapdropDown.AddOptions(maps);
    }

    // This function checks for the dropdown value (0-1) and changes the value of map
    // everytime the user selects a different value from the dropdown.
    void checkMapSelected(Dropdown mapSelected)
    {
        mapValue = mapSelected.value;
    }

}


