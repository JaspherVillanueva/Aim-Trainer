using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{

    public string name;
    public int score;
    public float accuracy;
    public int map;

    public PlayerData(string name, int score, float accuracy, int map)
    {
        name = name;
        score = score;
        accuracy = accuracy;
        map = map;
    }

}
