using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScreen : MonoBehaviour
{
    public void goToLoginScreen()
    {
        Debug.Log("Going to main menu");
        SceneManager.LoadScene("Login Screen");
    }
}