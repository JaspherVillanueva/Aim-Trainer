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
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Escape))  //if user presses B
        {
            Debug.Log("escape key pressed");
=======
        if (Input.GetKey(KeyCode.B))  //if user presses B
        {
            //Debug.Log("escape key pressed");
>>>>>>> Jarred
            if (GameIsPaused) //if game is already paused
            {
                Close();    //resume game
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
<<<<<<< HEAD
=======
                //wait
>>>>>>> Jarred
            }
            else
            {
                Open();    // pasuse game
                Cursor.lockState = CursorLockMode.None;   //unlock cursor to use in menu
<<<<<<< HEAD
            }                                           
=======
                //wait
            }
>>>>>>> Jarred
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
