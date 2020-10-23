using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int TargetsHit;
    public static int BulletsShot;
    public static float Accuracy;

    public void EndGame()
    {
        Debug.Log("Game Over");

        Debug.Log("Targets Hit: " + TargetsHit);
        Debug.Log("Bullets Shot: " + BulletsShot);

        if (TargetsHit != 0)
        {
            Accuracy = (TargetsHit * 100) / BulletsShot;
            Debug.Log(Accuracy + "%");
        }


        Debug.Log(ScoreScript.scoreValue);
        SceneManager.LoadScene("Game Over");
    }
}
