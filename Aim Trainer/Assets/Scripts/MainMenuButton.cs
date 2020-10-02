using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void MainMenu()
    {
        Debug.Log("Going Back to Main Menu");
        SceneManager.LoadScene("StartMenu");
    }
}
