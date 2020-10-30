using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class is used to control scene transitions using the buttons 
// found in each menu of each scene. Each function is named in relation
// to the scene that it wishes to transition to.

// Aim Trainer - 2020 - Jaspher Villanueva

public class SceneController : MonoBehaviour
{
    private static int mapSelection;

    public void goToMainMenu()
    {
        Debug.Log("Going to Main Menu Scene");
        SceneManager.LoadScene("Main Menu");
    }

    public void goToModeSelect()
    {
        Debug.Log("Going to Mode Select Scene");
        SceneManager.LoadScene("Mode Select");
    }

    public void goToRanking()
    {
        Debug.Log("Going to Ranking Scene");
        SceneManager.LoadScene("Ranking");
    }

    public void goToExitMenu()
    {
        Debug.Log("Going to Exit Menu Scene");
        SceneManager.LoadScene("Exit Menu");
    }
    
    public void goToMode1PreGame()
    {
        Debug.Log("Going to Pre Game Scene");
        SceneManager.LoadScene("Mode 1 Pre Game");
    }

    // The function checkMapSelect is used to check a map selection input from the pre game
    // menu to transition them into the selected map using the scene controller.

    public void checkMapSelect()
    {
        mapSelection = MapDropdown.mapValue;

        if (mapSelection == 0)
        {
            goToMap1();
        }

        else if (mapSelection == 1)
        {
            goToMap2();
        }
    }

    public void goToMap1()
    {
        Debug.Log("Going to The Ring");
        SceneManager.LoadScene("The Ring");
    }

    public void goToMap2()
    {
        Debug.Log("Going to Stair Master");
        SceneManager.LoadScene("Stair Master");
    }

    public void goToMode2PreGame()
    {
        Debug.Log("Going to Pre Game Scene for Mode 2");
        SceneManager.LoadScene("Mode 2 Pre Game");
    }

    public void goToMode2()
    {
        Debug.Log("Going to the Ring 2");
        SceneManager.LoadScene("The Ring 2");
    }

    public void goToMode3PreGame()
    {
        Debug.Log("Going to Pre Game Scene for Mode 3");
        SceneManager.LoadScene("Mode 3 Pre Game");
    }

    public void goToMode3()
    {
        Debug.Log("Going to Stair Master 2");
        SceneManager.LoadScene("Stair Master 2");
    }


}