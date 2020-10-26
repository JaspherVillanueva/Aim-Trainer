using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CrosshairOptions : MonoBehaviour
{
    public GameObject North;   //set of objects on the crosshair in the options menu
    public GameObject South;
    public GameObject West;
    public GameObject East;
    public GameObject Center;

    public GameObject NorthG;   //set of objects on the crosshair in the game
    public GameObject SouthG;
    public GameObject WestG;
    public GameObject EastG;
    public GameObject CenterG;

    public static float thicknessNS = 0.7f;    //original proportions of the crosshair
    public static float thicknessEW = 1;
    public static float lengthNS = 5;
    public static float lengthEW = 3;

    public static bool IsEnabled = true;

    public void thicknessOut()
    {
        Vector3 VectorN = new Vector3(thicknessNS, lengthNS, 0);    //vectors for tickness
        Vector3 VectorS = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorW = new Vector3(thicknessEW, lengthEW, 0);
        Vector3 VectorE = new Vector3(thicknessEW, lengthEW, 0);

        North.transform.localScale = VectorN;   //update the crosshair in options menu
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        NorthG.transform.localScale = VectorN;    //update the crosshair in game
        SouthG.transform.localScale = VectorS;
        EastG.transform.localScale = VectorE;
        WestG.transform.localScale = VectorW;

        thicknessNS += 0.05f;    //update new thickness value for next time
        thicknessEW += 0.1f;

        Debug.Log("Crosshair thickness out");
    }

    public void thicknessIn()
    {
        Vector3 VectorN = new Vector3(thicknessNS, lengthNS, 0);         //vectors for tickness
        Vector3 VectorS = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorW = new Vector3(thicknessEW, lengthEW, 0);
        Vector3 VectorE = new Vector3(thicknessEW, lengthEW, 0);

        North.transform.localScale = VectorN;          //update the crosshair in options menu
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        NorthG.transform.localScale = VectorN;           //update the crosshair in game
        SouthG.transform.localScale = VectorS;
        EastG.transform.localScale = VectorE;
        WestG.transform.localScale = VectorW;

        thicknessNS -= 0.05f;   //update new thickness value for next time
        thicknessEW -= 0.1f;

        Debug.Log("Crosshair thickness in");
    }

    public void lengthOut()
    {
        Vector3 VectorN = new Vector3(thicknessNS, lengthNS, 0);   //vectors for length
        Vector3 VectorS = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorW = new Vector3(thicknessEW, lengthEW, 0);
        Vector3 VectorE = new Vector3(thicknessEW, lengthEW, 0);

        North.transform.localScale = VectorN;       //update the crosshair in options menu
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        NorthG.transform.localScale = VectorN;         //update the crosshair in game
        SouthG.transform.localScale = VectorS;
        EastG.transform.localScale = VectorE;
        WestG.transform.localScale = VectorW;

        lengthNS += 0.4f;                            //update new length value for next time
        lengthEW += 0.28f;

        Debug.Log("Crosshair length out");
    }

    public void lengthIn()
    {
        Vector3 VectorN = new Vector3(thicknessNS, lengthNS, 0);         //vectors for length
        Vector3 VectorS = new Vector3(thicknessNS, lengthNS, 0);
        Vector3 VectorW = new Vector3(thicknessEW, lengthEW, 0);
        Vector3 VectorE = new Vector3(thicknessEW, lengthEW, 0);

        North.transform.localScale = VectorN;   //update the crosshair in options menu
        South.transform.localScale = VectorS;
        East.transform.localScale = VectorE;
        West.transform.localScale = VectorW;

        NorthG.transform.localScale = VectorN;   //update the crosshair in game
        SouthG.transform.localScale = VectorS;
        EastG.transform.localScale = VectorE;
        WestG.transform.localScale = VectorW;

        lengthNS -= 0.4f;               //update new length value for next time
        lengthEW -= 0.28f;

        Debug.Log("Crosshair length in");
    }

    public void sizeOut()
    {
        Vector3 VectorN = new Vector3(0.1f, 0.1f, 0);         //vectors for size

        Center.transform.localScale += VectorN;              //update the center dot size in options menu

        CenterG.transform.localScale += VectorN;        //update the center dot size in game

        Debug.Log("Center Out");
    }

    public void sizeIn()
    {
        Vector3 VectorN = new Vector3(0.1f, 0.1f, 0);            //vectors for size

        Center.transform.localScale -= VectorN;                    //update the center dot size in options menu

        CenterG.transform.localScale -= VectorN;                //update the center dot size in game

        Debug.Log("Center In");
    }

    public void CenterDot()
    {
        if (IsEnabled == true)
        {
            Center.SetActive(false);    //disable the center dot in options menu
            CenterG.SetActive(false);    //disable the center dot in game
            IsEnabled = false;         //update value

            Debug.Log("Center disabled");
        }
        else
        {
            Center.SetActive(true);   //disable the center dot in options menu
            CenterG.SetActive(true);  //disable the center dot in game
            IsEnabled = true;        //update value

            Debug.Log("Center enabled");
        }
    }
}
