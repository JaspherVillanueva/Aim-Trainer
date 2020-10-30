using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class is used to control map selection for mode 1.
// The map selected by the user through the GUI is passed into the scene controller
// Thus checking which map is selected for the that map scene to be loaded.

// Aim Trainer - 2020 - Jaspher Villanueva

public class GameDifficulty : MonoBehaviour
{
    private List<string> gameDifficulties = new List<string>() { "Easy", "Medium", "Hard" };
   
    private enum difficulty { Easy = 5, Medium = 3, Hard = 1};

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

    void addDifficulty(List <string> gameDifficulties)
    {
        gameDifficultyDropdown.AddOptions(gameDifficulties);
    }

    void checkGameDifficulty(Dropdown selectedDifficulty)
    {
        gameDifficultyValue = selectedDifficulty.value;

        if (gameDifficultyValue == 0)
        {
            waveTimer = (int)difficulty.Easy;
        }
        else if (gameDifficultyValue == 1)
        {
            waveTimer = (int)difficulty.Medium;
        }
        else if (gameDifficultyValue == 2)
        {
            waveTimer = (int)difficulty.Hard;
        }
    }

}

