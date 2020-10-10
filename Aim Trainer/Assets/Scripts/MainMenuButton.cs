using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void goToMainMenu()
    {
        Debug.Log("Going back to main menu");
        SceneManager.LoadScene("Log In");
    }
}