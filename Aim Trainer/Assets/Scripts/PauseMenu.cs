using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public static bool OpMenu = false;

    public GameObject pauseMenuUI;

    public GameObject disableGun;

    public GameObject disableCrosshair;

    public GameObject InGameOptionsMenu;

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                InGameOptionsMenu.SetActive(false);
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                InGameOptionsMenu.SetActive(false);
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        disableGun.SetActive(true);
        disableCrosshair.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void OptionsMenu ()
    {
        Debug.Log("Loading Options scene");
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame ()
    {
        Debug.Log("Quitting Game....");
        Application.Quit();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        disableGun.SetActive(false);
        disableCrosshair.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void InGameOpMenu ()
    {
        if(OpMenu == true)
        {
            InGameOptionsMenu.SetActive(true);
            pauseMenuUI.SetActive(false);
            OpMenu = false;
        }
        else
        {
            InGameOptionsMenu.SetActive(false);
            pauseMenuUI.SetActive(true);
            OpMenu = true;
        }
        
    }
}
