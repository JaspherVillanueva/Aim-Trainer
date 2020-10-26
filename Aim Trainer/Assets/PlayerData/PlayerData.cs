using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData", fileName = "Player 1")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int playerScore;
    public float playerAccuracy;
    public int playerMap;
    public int playerMode;
}
