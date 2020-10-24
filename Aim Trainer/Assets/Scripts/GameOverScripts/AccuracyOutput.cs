
using UnityEngine;
using UnityEngine.UI;

public class AccuracyOutput : MonoBehaviour
{
    public Text accuracyText;
    public static float accuracy;

    void Start()
    {
        accuracyText = GetComponent<Text>();
    }

    void Update()
    {
        accuracy = GameManager.Accuracy;
        accuracyText.text = accuracy.ToString() + "%";
    }

}