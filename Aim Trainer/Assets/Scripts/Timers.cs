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
        startTime = startTime - Time.deltaTime;

        string minutes = ((int)startTime / 60).ToString();
        string seconds = ((int)startTime % 60).ToString();

        timerText.text = minutes + ":" + seconds;
        
        if (startTime <= 0)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void AddTime ()
    {
        startTime += 30;
    }

    public void ReduceTime ()
    {
        startTime -=  30;
    }
}
