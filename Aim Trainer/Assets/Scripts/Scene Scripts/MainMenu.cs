using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void goToMainMenu()
    {
        Debug.Log("Going to main menu");
        SceneManager.LoadScene("Main Menu");
    }
}