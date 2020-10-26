using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapDropdown : MonoBehaviour
{
    List<string> maps = new List<string>() { "The Ring", "Stair Master", "The Shelf" };

    public Dropdown mapdropDown;
    public static int mapValue;

    void Start()
    {
        mapdropDown = GetComponent<Dropdown>();
        mapdropDown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(mapdropDown);
        });
        mapdropDown.AddOptions(maps);
        Debug.Log("Selected Map Index: " +
        mapdropDown.value);

    }

    void DropdownValueChanged(Dropdown change)
    {
        mapValue = change.value;
        Debug.Log(mapValue.ToString());
    }

}


