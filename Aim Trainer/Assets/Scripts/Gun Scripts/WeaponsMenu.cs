﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
            }
            else
            {
                Open();    // pause game
            }
        }
    }
    
    public void Open()
    {
        WeaponsMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Close()
    {
        WeaponsMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
