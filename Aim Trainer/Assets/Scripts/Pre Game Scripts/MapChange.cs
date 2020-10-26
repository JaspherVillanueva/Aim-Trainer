using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapChange : MonoBehaviour
{
    public Sprite map1;
    public Sprite map2;
    public Sprite map3;
    public Image mapPanel;
    public static int mapSelected;

    void Start()
    {
        mapPanel = GetComponent<Image>();

    }
    
    void Update()
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
        else if (mapSelected == 2)
        {
            mapPanel.sprite = map3;
        }


    }
}
