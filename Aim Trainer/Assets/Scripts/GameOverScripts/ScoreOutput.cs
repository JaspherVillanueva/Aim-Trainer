
using UnityEngine;
using UnityEngine.UI;

public class ScoreOutput : MonoBehaviour
{
    public Text scoreText;
    public static int score;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        score = ScoreScript.scoreValue;
        scoreText.text = score.ToString();
    }

}
