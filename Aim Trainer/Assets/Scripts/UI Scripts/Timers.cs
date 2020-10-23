using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timers : MonoBehaviour
{
    public Text timerText;

    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime >= 0)   //if time > 0, countdown
        {
            startTime = startTime - Time.deltaTime; //start time - 1 second

            string minutes = ((int)startTime / 60).ToString();  //start time minutes
            string seconds = ((int)startTime % 60).ToString();  //start time seconds

            if((int)startTime % 60 < 10)
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
            Cursor.lockState = CursorLockMode.None;     //Unlock the mouse to use for the 
        }
    }

    public void AddTime ()  //function to add 30 seconds to timer
    {
        startTime += 30;
    }

    public void ReduceTime ()  //function to reduce time by 30s
    {
        if (startTime > 30)
        {
            startTime -= 30;
        }
        else
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("Exit Menu");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
