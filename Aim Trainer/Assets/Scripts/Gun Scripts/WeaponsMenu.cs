using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class WeaponsMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject WeaponsMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))  //if user presses B
        {
            //Debug.Log("escape key pressed");
            if (GameIsPaused) //if game is already paused
            {
                Close();    //resume game
                Wait();     //prevent spamming
            }
            else
            {
                Open();    // pause game 
                Wait();    //prevent menu spamming
            }
        }
    }

    public void Open()
    {
        Cursor.visible = false;                     //make cursor invisible
        Cursor.lockState = CursorLockMode.Locked;   // lock cursor for game

        WeaponsMenuUI.SetActive(true);
        GameIsPaused = true;

        Time.timeScale = 0f;
    }

    public void Close()
    {
        Cursor.visible = true;                    //make cursor visible
        Cursor.lockState = CursorLockMode.None;   //unlock cursor to use in menu

        WeaponsMenuUI.SetActive(false);

        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    IEnumerator Wait()  //wait so player cant open and close bying menu rapidly
    {
        yield return new WaitForSeconds(1);
    }
}
