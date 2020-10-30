using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotDifficulty: MonoBehaviour   //change difficulty on moving target scene
{
    List<string> botDifficulties = new List<string>() { "Easy", "Medium", "Hard"};

    public Dropdown botDifficultyDropdown;
    public int botCountValue;
    public static float botRotationSpeed=5f;
    public static float botSpeed= 2f;

    void Start()
    {
        botDifficultyDropdown = GetComponent<Dropdown>();   //get the value from the dropdown in menu
        botDifficultyDropdown.onValueChanged.AddListener
            (delegate
            {
                DropdownValueChanged(botDifficultyDropdown);
            });

        botDifficultyDropdown.AddOptions(botDifficulties);
        botCountValue = botDifficultyDropdown.value;
        Debug.Log("Starting Bot Count Difficulty Value "
            + botDifficultyDropdown.value);
    }

    void DropdownValueChanged(Dropdown changeBot)   //set difficulty based on the value sent back from the dropdown
    {
        botCountValue = changeBot.value;
        if (botCountValue == 0)
        {
            botRotationSpeed = botRotationSpeed;
            botSpeed = botSpeed;
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
