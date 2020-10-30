using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is ued to control bot difficulty for mode 2 (Bot Practice).
// The bot difficulty selected by the user through the GUI is passed into the game.
// Thus setting the rotation speed and speed of the bot as it rotates around the circle.

// Aim Trainer - 2020 - Jaspher Villanueva

public class BotDifficulty: MonoBehaviour
{
    private List<string> botDifficulties = new List<string>() { "Easy", "Medium", "Hard"};

    // enum variables containing ints of each difficulty's bot speed going to and out of the center.
    private enum speed { Easy = 2, Medium = 5, Hard = 8 };

    // enum variables containing ints of each difficulty's bot rotation speed around the center.
    private enum rotationSpeed { Easy = 5, Medium = 7, Hard = 12 };

    public Dropdown botDifficultyDropdown;

    private int botCountValue;

    public static float botRotationSpeed = (int)rotationSpeed.Easy;

    public static float botSpeed = (int)speed.Easy;

    void Start()
    {
        botDifficultyDropdown = GetComponent<Dropdown>();

        botDifficultyDropdown.onValueChanged.AddListener(delegate
        {
            checkBotDifficulty(botDifficultyDropdown);
        });

        addBotDifficulties(botDifficulties);
    }

    // This function adds the list variables into the bot difficulty dropdown
    void addBotDifficulties(List<string> botDifficulties)
    {
        botDifficultyDropdown.AddOptions(botDifficulties);
    }

    // This function checks for the dropdown value (0-2) and changes the value of the game
    // everytime the user selects a different value from the dropdown.
    // Thus setting the rotation speed and speed of the bot based on difficulty.
    void checkBotDifficulty(Dropdown botDifficulty)
    {
        botCountValue = botDifficulty.value;

        if (botCountValue == 0)
        {
            setRotationSpeed((int)rotationSpeed.Easy);
            setSpeed((int)speed.Easy);
            
        }
        else if (botCountValue == 1)
        {
            setRotationSpeed((int)rotationSpeed.Medium);
            setSpeed((int)speed.Medium); ;
        }
        else if (botCountValue == 2)
        {
            setRotationSpeed((int)rotationSpeed.Hard);
            setSpeed((int)speed.Hard);
        }
    }

    void setRotationSpeed(int rotationSpeed)
    {
        botRotationSpeed = rotationSpeed;
    }

    void setSpeed(int speed)
    {
        botSpeed = speed;
    }
}
