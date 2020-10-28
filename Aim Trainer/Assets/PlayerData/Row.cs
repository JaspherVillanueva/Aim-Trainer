using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{
    public PlayerData player;

    public Text playerNametxt;
    public Text playerScoretxt;
    public Text playerAccuracytxt;

    private void Start()
    {
        UpdateRow();

    }
 
    public void UpdateRow()
    {
        playerNametxt.text = player.playerName;
        playerScoretxt.text = player.playerScore.ToString();
        playerAccuracytxt.text = player.playerAccuracy.ToString() + "%";
    }
}
