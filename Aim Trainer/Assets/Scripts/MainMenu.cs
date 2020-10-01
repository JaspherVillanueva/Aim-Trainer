using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Main()
    {
        Debug.Log("Going Back to main scene...");
        SceneManager.LoadScene("Start Menu");
    }
}
