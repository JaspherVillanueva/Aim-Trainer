using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoresScript : MonoBehaviour
{
    public Text originalScore;

    public Text Score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Score.text = originalScore.text;
    }
}

