using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SyncTime : MonoBehaviour
{
    public Text originalTime;

    public Text menuTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        menuTime.text = originalTime.text;
    }
}
