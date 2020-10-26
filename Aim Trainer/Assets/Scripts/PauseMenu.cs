using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public static bool OpMenu = false; //chaeck if game is paused

    public GameObject pauseMenuUI;   //the menu

    public GameObject disableGun;  //disable gun when menu is open

    public GameObject disableCrosshair;  //disable crosshair when menu is open

    public GameObject InGameOptionsMenu;    //options menu

    public GameObject WeaponsMenu;    //options menu

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape))  //if user presses esc
        {
            if(GameIsPaused) //if game is already paused
            {
                Resume();   //resume game
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                InGameOptionsMenu.SetActive(false);
            }
            else
            {
                Pause();  // pasuse game
                Cursor.lockState = CursorLockMode.None;   //unlock cursor to use in menu
                InGameOptionsMenu.SetActive(false);         //disable options menu if opened
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);        //disable pause menu
        disableGun.SetActive(true);          //bring back gun
        disableCrosshair.SetActive(true);    //bring back crosshair
        Time.timeScale = 1f;                 //resume time
        GameIsPaused = false;                //update value
        WeaponsMenu.SetActive(false);
    }

    public void QuitGame ()
    {
        Debug.Log("Quitting Game....");
        Application.Quit();  //quitting game
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);         //bring up pause menu
        disableGun.SetActive(false);         //disable gun
        disableCrosshair.SetActive(false);   //disable crosshair
        Time.timeScale = 0f;                 //stop time, aka pause the game
        GameIsPaused = true;                 //update value
        WeaponsMenu.SetActive(false);

    }

    public void InGameOpMenu ()   //bring up options menu
    {
        if(OpMenu == true) //if the menu is not on
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
