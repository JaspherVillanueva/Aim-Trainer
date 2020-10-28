using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public static bool OpMenu = true; //check if game is paused

    public GameObject pauseMenuUI;   //the menu

    public GameObject disableGun;  //disable gun when menu is open

    public GameObject disableCrosshair;  //disable crosshair when menu is open

    public GameObject InGameOptionsMenu;    //options menu

    public GameObject WeaponsMenu;    //options menu

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //if user presses esc
        {
            if (GameIsPaused) //if game is already paused
            {
                Resume();   //resume game
            }
            else
            {
                Pause();  // pause game
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;                     //make cursor invisible
        Cursor.lockState = CursorLockMode.Locked;   //lock cursor to use in menu

        InGameOptionsMenu.SetActive(false);
        pauseMenuUI.SetActive(false);        //disable pause menu
        disableGun.SetActive(true);          //bring back gun
        disableCrosshair.SetActive(true);    //bring back crosshair
        WeaponsMenu.SetActive(true);         //disable weapon bying menu

        Time.timeScale = 1f;                 //resume time
        GameIsPaused = false;                //update value

    }

    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;   //unlock cursor to use in menu

        InGameOptionsMenu.SetActive(false);         //disable options menu if opened
        pauseMenuUI.SetActive(true);         //bring up pause menu
        disableGun.SetActive(false);         //disable gun
        disableCrosshair.SetActive(false);   //disable crosshair
        WeaponsMenu.SetActive(false);         //disable weapon bying menu

        Time.timeScale = 0f;                 //stop time, aka pause the game
        GameIsPaused = true;                 //update value
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game....");
        Application.Quit();                //quitting game
    }

    public void InGameOpMenu()   //bring up options menu
    {
        if (OpMenu == true) //if the menu is not on
        {
            InGameOptionsMenu.SetActive(true); //open the options menu
            pauseMenuUI.SetActive(false);      //disable pause menu
            OpMenu = false;                    //update value
        }
        else
        {
            InGameOptionsMenu.SetActive(false);//disable options menu
            pauseMenuUI.SetActive(true);       //bring back pause menu
            OpMenu = true;                     //update value
        }
    }
}
