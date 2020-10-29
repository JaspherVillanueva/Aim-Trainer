using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public string saveName = NameInput.playerName;
    public int saveScore = ScoreScript.scoreValue;
    public float saveAccuracy;
    public int saveMap;
    public List<PlayerData> players = new List<PlayerData>();
    public PlayerData player;

    void Start()
    {


        saveName = NameInput.playerName;
        saveScore = ScoreScript.scoreValue;
        saveAccuracy = GameManager.Accuracy;
        saveMap = MapDropdown.mapValue;

        player = new PlayerData(saveName, saveScore, saveAccuracy, saveMap);

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
