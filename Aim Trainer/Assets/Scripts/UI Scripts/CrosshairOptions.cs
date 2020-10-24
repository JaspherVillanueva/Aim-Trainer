using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairOptions : MonoBehaviour
{
    public GameObject North;
    public GameObject South;
    public GameObject West;
    public GameObject East;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void offsetOut()
    {
        North.transform.position(North.transform.position.x, North.transform.position.y + 1, 0);
        South.transform.position(South.transform.position.x, South.transform.position.y - 1, 0);
        East.transform.position(East.transform.position.x + 1, East.transform.position.y, 0);
        West.transform.position(West.transform.position.x - 1, West.transform.position.y, 0);
    }

    public void offsetIn()
    {
        North.transform.position(North.transform.position.x, North.transform.position.y - 1, 0);
        South.transform.position(South.transform.position.x, South.transform.position.y + 1, 0);
        East.transform.position(East.transform.position.x - 1, East.transform.position.y, 0);
        West.transform.position(West.transform.position.x + 1, West.transform.position.y, 0);
    }

    public void thicknessOut()
    {

    }

    public void thicknessIn()
    {

    }

    public void lengthOut()
    {

    }

    public void lengthIn()
    {

    }
}
