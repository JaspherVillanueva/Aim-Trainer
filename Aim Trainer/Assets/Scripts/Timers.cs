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
        startTime = 15;
    }

    // Update is called once per frame
    void Update()
    {
        float t = startTime - Time.deltaTime;
        startTime = t;

        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)t % 60).ToString();

        timerText.text = minutes + ":" + seconds;
        
        if (startTime <= 0)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("GameOver");
        }
    }
}
