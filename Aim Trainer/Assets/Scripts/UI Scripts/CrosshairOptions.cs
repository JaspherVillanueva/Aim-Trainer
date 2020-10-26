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

    public GameObject NorthG;
    public GameObject SouthG;
    public GameObject WestG;
    public GameObject EastG;
    public GameObject CenterG;

    public static float thicknessNS = 0.7f;
    public static float thicknessEW = 1;
    public static float lengthNS = 5;
    public static float lengthEW = 3;

    public static bool IsEnabled = true;

    public void thicknessOut()
    {
        Vector3 VectorN = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorS = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorW = new Vector3(thicknessEW, lengthEW, 0);
        Vector3 VectorE = new Vector3(thicknessEW, lengthEW, 0);

        North.transform.localScale = VectorN;
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        NorthG.transform.localScale = VectorN;
        SouthG.transform.localScale = VectorS;
        EastG.transform.localScale = VectorE;
        WestG.transform.localScale = VectorW;

        thicknessNS += 0.05f;
        thicknessEW += 0.1f;

        Debug.Log("Crosshair thickness out");
    }

    public void thicknessIn()
    {
        Vector3 VectorN = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorS = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorW = new Vector3(thicknessEW, lengthEW, 0);
        Vector3 VectorE = new Vector3(thicknessEW, lengthEW, 0);

        North.transform.localScale = VectorN;
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        NorthG.transform.localScale = VectorN;
        SouthG.transform.localScale = VectorS;
        EastG.transform.localScale = VectorE;
        WestG.transform.localScale = VectorW;

        thicknessNS -= 0.05f;
        thicknessEW -= 0.1f;

        Debug.Log("Crosshair thickness in");
    }

    public void lengthOut()
    {
        Vector3 VectorN = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorS = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorW = new Vector3(thicknessEW, lengthEW, 0);
        Vector3 VectorE = new Vector3(thicknessEW, lengthEW, 0);

        North.transform.localScale = VectorN;
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        NorthG.transform.localScale = VectorN;
        SouthG.transform.localScale = VectorS;
        EastG.transform.localScale = VectorE;
        WestG.transform.localScale = VectorW;

        lengthNS += 0.4f;
        lengthEW += 0.28f;

        Debug.Log("Crosshair length out");
    }

    public void lengthIn()
    {
        Vector3 VectorN = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorS = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorW = new Vector3(thicknessEW, lengthEW, 0);
        Vector3 VectorE = new Vector3(thicknessEW, lengthEW, 0);

        North.transform.localScale = VectorN;
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        NorthG.transform.localScale = VectorN;
        SouthG.transform.localScale = VectorS;
        EastG.transform.localScale = VectorE;
        WestG.transform.localScale = VectorW;

        lengthNS -= 0.4f;
        lengthEW -= 0.28f;

        Debug.Log("Crosshair length in");
    }

    public void sizeOut()
    {
        Vector3 VectorN = new Vector3(0.1f, 0.1f, 0);

        Center.transform.localScale += VectorN;

        CenterG.transform.localScale += VectorN;

        Debug.Log("Center Out");
    }

    public void sizeIn()
    {
        Vector3 VectorN = new Vector3(0.1f, 0.1f, 0);

        Center.transform.localScale -= VectorN;

        CenterG.transform.localScale -= VectorN;

        Debug.Log("Center In");
    }

    public void CenterDot()
    {
        if (IsEnabled == true)
        {
            Center.SetActive(false);
            CenterG.SetActive(false);
            IsEnabled = false;

            Debug.Log("Center disabled");
        }
        else
        {
            Center.SetActive(true);
            CenterG.SetActive(true);
            IsEnabled = true;

            Debug.Log("Center enabled");
        }
    }
}
