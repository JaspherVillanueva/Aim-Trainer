using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginMenu : MonoBehaviour
{
    public void goToLogin()
    {
        Debug.Log("Going to login menu");
        SceneManager.LoadScene("Login Menu");
    }
}

