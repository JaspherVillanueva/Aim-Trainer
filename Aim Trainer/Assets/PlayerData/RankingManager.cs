using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public List<PlayerData> players = new List<PlayerData>();

    private void Start()
    {
        getHighestScore();
    }

    private string getHighestScore()
    {
        int highestScore = 0;
        string bestPlayer = " ";

        for(int i = 0; i < players.Count; i++)
        {
            if(players[i].playerScore > highestScore)
            {
               highestScore = players[i].playerScore;
               bestPlayer = players[i].playerName;
            }

            
        }
        return bestPlayer;
    }


}
