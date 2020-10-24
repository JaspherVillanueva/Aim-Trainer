using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    public void goToModeSelect()
    {
        Debug.Log("Going to mode select");
        SceneManager.LoadScene("Mode Select");
    }
}