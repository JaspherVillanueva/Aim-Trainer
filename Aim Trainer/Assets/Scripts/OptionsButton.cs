using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButton : MonoBehaviour
{
    public void Options()
    {
        Debug.Log("Going Back to main scene...");
        SceneManager.LoadScene("OptionsMenu");
    }
}
