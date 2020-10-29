using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData {

    public string name;
    public int score;
    public float accuracy;
    public int map;

    public PlayerData (SaveData player)
    {
        name = player.saveName;
        score = player.saveScore;
        accuracy = player.saveAccuracy;
        map = player.saveMap;
    }
 
}
