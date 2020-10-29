using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotDifficulty: MonoBehaviour
{
    List<string> botDifficulties = new List<string>() { "Easy", "Medium", "Hard"};

    public Dropdown botDifficultyDropdown;
    public int botCountValue;
    public static float botRotationSpeed=5f;
    public static float botSpeed= 10f;

    void Start()
    {
        botDifficultyDropdown = GetComponent<Dropdown>();
        botDifficultyDropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(botDifficultyDropdown);
        });
        botDifficultyDropdown.AddOptions(botDifficulties);
        botCountValue = botDifficultyDropdown.value;
        Debug.Log("Starting Bot Count Difficulty Value "
            + botDifficultyDropdown.value);
    }

    void DropdownValueChanged(Dropdown changeBot)
    {
        botCountValue = changeBot.value;

        if (botCountValue == 0)
        {
            botRotationSpeed = 5f;
            botSpeed = 2f;
        }
        else if (botCountValue == 1)
        {
            botRotationSpeed = 7f;
            botSpeed = 5f;
        }
        else if (botCountValue == 2)
        {
            botRotationSpeed = 12f;
            botSpeed = 8f;
        }

        Debug.Log(botCountValue);

    }

}
