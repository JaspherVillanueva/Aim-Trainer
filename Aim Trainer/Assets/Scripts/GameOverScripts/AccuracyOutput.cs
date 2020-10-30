using UnityEngine;
using UnityEngine.UI;

// This class is used to output accuracy into the game over scene.

public class AccuracyOutput : MonoBehaviour
{
    public Text accuracyText;
    private static float accuracy;

    void Start()
    {
        accuracyText = GetComponent<Text>();
    }

    void Update()
    {
        setAccuracy();
        showAccuracy();
    }

    void setAccuracy()
    {
        accuracy = GameManager.Accuracy;
    }


    public void showAccuracy()
    {
        accuracyText.text = accuracy.ToString() + "%";
    }


}