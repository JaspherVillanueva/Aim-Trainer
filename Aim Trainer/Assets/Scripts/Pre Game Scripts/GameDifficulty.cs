using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is ued to control game difficulty for mode 3 (Peek-A-Boo).
// The difficulty selected by the user through the GUI is passed into the game.
// Thus setting the time of spawn between each target before it disappears again.

// Aim Trainer - 2020 - Jaspher Villanueva

public class GameDifficulty : MonoBehaviour
{
    private List<string> gameDifficulties = new List<string>() { "Easy", "Medium", "Hard" };

    // enum variables containing ints of each difficulty.
    private enum difficulty { Easy = 5, Medium = 3, Hard = 1 };

    public Dropdown gameDifficultyDropdown;

    private int gameDifficultyValue;

    public static int waveTimer = (int)difficulty.Easy;

    void Start()
    {
        gameDifficultyDropdown = GetComponent<Dropdown>();

        gameDifficultyDropdown.onValueChanged.AddListener(delegate
        {
            checkGameDifficulty(gameDifficultyDropdown);
        });

        addDifficulty(gameDifficulties);

    }

    // This function adds the list variables into the map dropdown
    void addDifficulty(List<string> gameDifficulties)
    {
        gameDifficultyDropdown.AddOptions(gameDifficulties);
    }

    // This function checks for the dropdown value (0-1) and changes the value of the game
    // everytime the user selects a different value from the dropdown.
    void checkGameDifficulty(Dropdown selectedDifficulty)
    {
        gameDifficultyValue = selectedDifficulty.value;

        if (gameDifficultyValue == 0)
        {
            setWaveTimer((int)difficulty.Easy);
        }
        else if (gameDifficultyValue == 1)
        {
            setWaveTimer((int)difficulty.Medium);
        }
        else if (gameDifficultyValue == 2)
        {
            setWaveTimer((int)difficulty.Hard);
        }
    }

    void setWaveTimer(int timer)
    {
        waveTimer = timer;
    }

}

