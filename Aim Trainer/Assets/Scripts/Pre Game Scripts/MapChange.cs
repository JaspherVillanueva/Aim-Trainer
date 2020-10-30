using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is used to control the map image for mode 1. 
// The map selected by the user through the dropdown is passed into this class.
// Thus updating the map image based on the map dropdown selection.

// Aim Trainer - 2020 - Jaspher Villanueva

public class MapChange : MonoBehaviour
{
    public Sprite map1;
    public Sprite map2;
    public Image mapPanel;
    public static int mapSelected;

    void Start()
    {
        mapPanel = GetComponent<Image>();
    }
    
    void Update()
    {
        checkMapSelection(mapSelected);
    }

    // This function checks for the map value selected in the dropdown and updates 
    // the image panel based on the selection.
    void checkMapSelection(int mapSelected)
    {
        mapSelected = MapDropdown.mapValue;

        if (mapSelected == 0)
        {
            mapPanel.sprite = map1;
        }
        else if (mapSelected == 1)
        {
            mapPanel.sprite = map2;
        }
    }




}
