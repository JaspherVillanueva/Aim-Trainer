using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject disableGun;

    public GameObject disableCrosshair;

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
            }
            else
            {
                Pause();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
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
}
