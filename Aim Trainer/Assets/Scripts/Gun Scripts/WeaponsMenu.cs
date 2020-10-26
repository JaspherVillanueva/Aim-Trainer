using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class WeaponsMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject WeaponsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))  //if user presses B
        {
            //Debug.Log("escape key pressed");
            if (GameIsPaused) //if game is already paused
            {
                Close();    //resume game
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                //wait
            }
            else
            {
                Open();    // pasuse game
                Cursor.lockState = CursorLockMode.None;   //unlock cursor to use in menu
                //wait
            }
        }
    }

    public void Open()
    {
        WeaponsMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void Close()
    {
        WeaponsMenuUI.SetActive(false);
        GameIsPaused = false;
    }
}
