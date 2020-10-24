using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CrosshairOptions : MonoBehaviour
{
    public GameObject North;
    public GameObject South;
    public GameObject West;
    public GameObject East;

    public GameObject Center;

    public static bool IsEnabled = true;

    public void offsetOut()
    {
        Vector3 VectorN = new Vector3(0, -0.5f, 0);
        Vector3 VectorS = new Vector3(0, 0.5f, 0);
        Vector3 VectorW = new Vector3(-0.5f, 0, 0);
        Vector3 VectorE = new Vector3(0.5f, 0, 0);

        North.transform.position = VectorN; 
        South.transform.position = VectorS;
        East.transform.position = VectorE;
        West.transform.position = VectorW;

        Debug.Log("Crosshair offset out");
    }

    public void offsetIn()
    {
        Vector3 VectorN = new Vector3(0, -0.3f, 0);
        Vector3 VectorS = new Vector3(0, 0.3f, 0);
        Vector3 VectorW = new Vector3(-0.3f, 0, 0);
        Vector3 VectorE = new Vector3(0.3f, 0, 0);

        North.transform.position = VectorN;
        South.transform.position = VectorS;
        East.transform.position = VectorE;
        West.transform.position = VectorW;

        Debug.Log("Crosshair offset in");
    }

    public void thicknessOut()
    {
        Vector3 VectorN = new Vector3(1, 5, 0);
        Vector3 VectorS = new Vector3(1, 5, 0);
        Vector3 VectorW = new Vector3(1.5f, 3, 0);
        Vector3 VectorE = new Vector3(1.5f, 3, 0);

        North.transform.localScale = VectorN;
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        Debug.Log("Crosshair thickness out");
    }

    public void thicknessIn()
    {
        Vector3 VectorN = new Vector3(0.4f, 5, 0);
        Vector3 VectorS = new Vector3(0.4f, 5, 0);
        Vector3 VectorW = new Vector3(0.7f, 3, 0);
        Vector3 VectorE = new Vector3(0.7f, 3, 0);

        North.transform.localScale = VectorN;
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        Debug.Log("Crosshair thickness in");
    }

    public void lengthOut()
    {
        Vector3 VectorN = new Vector3(0.4f, 6, 0);
        Vector3 VectorS = new Vector3(0.4f, 6, 0);
        Vector3 VectorW = new Vector3(0.7f, 4, 0);
        Vector3 VectorE = new Vector3(0.7f, 4, 0);

        North.transform.localScale = VectorN;
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        Debug.Log("Crosshair length out");
    }

    public void lengthIn()
    {
        Vector3 VectorN = new Vector3(0.4f, 3, 0);
        Vector3 VectorS = new Vector3(0.4f, 3, 0);
        Vector3 VectorW = new Vector3(0.7f, 2, 0);
        Vector3 VectorE = new Vector3(0.7f, 2, 0);

        North.transform.localScale = VectorN;
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        Debug.Log("Crosshair length in");
    }

    public void sizeOut()
    {
        Vector3 VectorN = new Vector3(1.2f, 1.2f, 0);

        Center.transform.localScale = VectorN;

        Debug.Log("Center Out");
    }

    public void sizeIn()
    {
        Vector3 VectorN = new Vector3(0.7f, 0.7f, 0);

        Center.transform.localScale = VectorN;

        Debug.Log("Center In");
    }

    public void CenterDot()
    {
        if (IsEnabled == true)
        {
            Center.SetActive(false);
            IsEnabled = false;

            Debug.Log("Center disabled");
        }
        else
        {
            Center.SetActive(true);
            IsEnabled = true;

            Debug.Log("Center enabled");
        }
    }
}
