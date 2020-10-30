using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    private string saveName;
    public int saveScore = ScoreScript.scoreValue;
    public float saveAccuracy;
    public int saveMap;
    public List<PlayerData> players = new List<PlayerData>();
    public PlayerData player;

    void Start()
    {


        
       

        /* Debug.Log(player.name);

         saveButton.onClick.AddListener(delegate
         {
             saveData(player);
         });
     }

    void saveData(PlayerData playerD)
     {
         players.Add(playerD);
         Debug.Log(player.score.ToString());

     }
     */
    }
}
