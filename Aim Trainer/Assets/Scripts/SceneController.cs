﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void goToLoginMenu()
    {
        Debug.Log("Going to Login Menu Scene");
        SceneManager.LoadScene("Login Menu");
    }

    public void goToLogin()
    {
        Debug.Log("Going to Login Scene");
        SceneManager.LoadScene("Login");
    }

    public void goToCreateAccount()
    {
        Debug.Log("Going to Create Account Scene");
        SceneManager.LoadScene("Create Account");
    }

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

    public void goToMap1()
    {
        Debug.Log("Going to Map 1");
        SceneManager.LoadScene("Aim Trainer");
    }

}