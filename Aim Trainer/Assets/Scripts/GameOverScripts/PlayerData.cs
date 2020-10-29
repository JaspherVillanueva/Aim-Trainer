using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{

    private string name;
    private int score;
    private float accuracy;
    private int map;

    public PlayerData(string name, int score, float accuracy, int map)
    {
        name = setName(name);
        score = setScore(score);
        accuracy = setAccuracy(accuracy);
        map = setMap(map);
    }

    public string setName(string name)
    {
        this.name = name;
        return this.name;
    }

    public int setScore(int score)
    {
        this.score = score;
        return this.score;
    }

    public float setAccuracy(float accuracy)
    {
        this.accuracy = accuracy;
        return this.accuracy;
    }

    public int setMap(int map)
    {
        this.map = map;
        return this.map;
    }
}
