using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public string saveName;
    public int saveScore;
    public float saveAccuracy;
    public int saveMap;

   

    void Start()
    {
      

        saveName = NameInput.playerName;
        saveScore = ScoreScript.scoreValue;
        saveAccuracy = GameManager.Accuracy;
        saveMap = MapDropdown.mapValue;

        Debug.Log(saveName);
        Debug.Log(saveScore.ToString());
        Debug.Log(saveAccuracy.ToString());
        Debug.Log(saveMap.ToString());

    }

    
}
