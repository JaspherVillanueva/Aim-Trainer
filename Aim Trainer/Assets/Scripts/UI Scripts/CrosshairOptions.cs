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

    public void offetOut()
    {
        North.transform.position(transform.position.x, transform.position.y + 1, transform.position.z);
        South.transform.position(transform.position.x, transform.position.y - 1, transform.position.z);
        East.transform.position(transform.position.x + 1, transform.position.y, transform.position.z);
        West.transform.position(transform.position.x - 1, transform.position.y, transform.position.z);
    }

    public void offetIn()
    {
        North.transform.position(transform.position.x, transform.position.y - 1, transform.position.z);
        South.transform.position(transform.position.x, transform.position.y + 1, transform.position.z);
        East.transform.position(transform.position.x - 1, transform.position.y, transform.position.z);
        West.transform.position(transform.position.x + 1, transform.position.y, transform.position.z);
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
