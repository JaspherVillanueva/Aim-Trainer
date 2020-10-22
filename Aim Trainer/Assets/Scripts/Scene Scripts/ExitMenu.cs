using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public void goToExitMenu()
    {
        Debug.Log("Going to exit menu");
        SceneManager.LoadScene("Exit Menu");
    }
}
