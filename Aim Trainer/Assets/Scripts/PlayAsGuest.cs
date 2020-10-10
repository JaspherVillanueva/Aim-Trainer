using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAsGuest : MonoBehaviour
{
    public void playAsGuest()
    {
        Debug.Log("Playing the game");
        SceneManager.LoadScene("AimTrainer");
    }
}
