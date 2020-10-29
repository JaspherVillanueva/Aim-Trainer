using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public string saveName;
    public int saveScore;
    public float saveAccuracy;
    public int saveMap;
    public PlayerData player;

    void Start()
    {
        saveButton = GetComponent<Button>();
        saveName = NameInput.playerName;
        saveScore = ScoreScript.scoreValue;
        saveAccuracy = GameManager.Accuracy;
        saveMap = MapDropdown.mapValue;

        saveButton.onClick.AddListener(delegate
        {
            saveData(saveName,saveScore,saveAccuracy,saveMap);
        });

        Debug.Log(saveName);
        Debug.Log(saveScore.ToString());
        Debug.Log(saveAccuracy.ToString());
        Debug.Log(saveMap.ToString());

    }

   void saveData(string saveName, int saveScore, float saveAccuracy, int saveMap)
    {

      player = new PlayerData(saveName, saveScore, saveAccuracy, saveMap);
       
    }



 
}
