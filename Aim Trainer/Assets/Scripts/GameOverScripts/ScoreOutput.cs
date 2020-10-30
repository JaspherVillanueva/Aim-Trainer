using UnityEngine;
using UnityEngine.UI;

// This class is used to output score into the game over scene.

public class ScoreOutput : MonoBehaviour
{
    public Text scoreText;
    private static int score;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        setScore();
        showScore();
    }

    public void setScore()
    {
        score = ScoreScript.scoreValue;
    }

    public void showScore()
    {
        scoreText.text = score.ToString();
    }
}
