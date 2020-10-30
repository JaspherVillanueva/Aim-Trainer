using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timers : MonoBehaviour
{
    public Text timerText;

    private static float startTime;

    void Start()
    {
        startTime = TimerDropdown.timer;
    }

    void Update()
    {
        if (startTime >= 0)   //if time > 0, countdown
        {
            startTime = startTime - Time.deltaTime; //start time - 1 second

            string minutes = ((int)startTime / 60).ToString();  //start time minutes
            string seconds = ((int)startTime % 60).ToString();  //start time seconds

            if((int)startTime % 60 < 10)   //if seconds is less than 0, add a 0 for aesthetics
            {
                timerText.text = minutes + ":0" + seconds;    //updates the timerText object
            }
            else
            {
                timerText.text = minutes + ":" + seconds;    //updates the timerText object
            }
        }
        else   //if time == 0, end game
        {
            Time.timeScale = 0f;
            FindObjectOfType<GameManager>().EndGame();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;     //Unlock the mouse to use for the endgame scene
        }
    }
}
