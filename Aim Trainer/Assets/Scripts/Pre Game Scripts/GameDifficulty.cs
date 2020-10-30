using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDifficulty : MonoBehaviour    //setting the difficulty 
{
    List<string> gameDifficulties = new List<string>() { "Easy", "Medium", "Hard" };

    public Dropdown gameDifficultyDropdown;
    public int gameDifficultyValue;
    public static float waveTimer = 10f;

    void Start()
    {
        gameDifficultyDropdown = GetComponent<Dropdown>();    //get the dropdown value in the menu
        gameDifficultyDropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(gameDifficultyDropdown);
        });
        gameDifficultyDropdown.AddOptions(gameDifficulties);
        gameDifficultyValue = gameDifficultyDropdown.value;
        Debug.Log("Starting Difficulty Value "
            + gameDifficultyDropdown.value);
    }

    void DropdownValueChanged(Dropdown changeBot)   //set the difficulty based on the value returned from the dropdown
    {
        gameDifficultyValue = changeBot.value;

        if (gameDifficultyValue == 0)
        {
            waveTimer = 5f;
            Debug.Log(waveTimer);
        }
        else if (gameDifficultyValue == 1)
        {
            waveTimer = 2.5f;
            Debug.Log(waveTimer);
        }
        else if (gameDifficultyValue == 2)
        {
            waveTimer = 1f;
            Debug.Log(waveTimer);
        }

        Debug.Log(gameDifficultyValue);

    }

}

