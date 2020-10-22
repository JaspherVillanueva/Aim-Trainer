using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAccount : MonoBehaviour
{
    public void goToCreateAccount()
    {
        Debug.Log("Going to Create Account");
        SceneManager.LoadScene("Create Account");
    }
}
