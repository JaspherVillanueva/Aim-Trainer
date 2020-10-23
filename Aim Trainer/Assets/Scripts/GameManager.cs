using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    public static int TargetsHit;
    public static int BulletsShot;

    public void EndGame()
    {
        Debug.Log("Game Over");

        //Debug.Log("Targets Hit: " + TargetsHit);
        //Debug.Log("Bullets Shot: " + BulletsShot);

        float Accuracy = (TargetsHit * 100) / BulletsShot;
        Debug.Log(Accuracy + "%");

        //Debug.Log(ScoreScript.scoreValue);
        //SceneManager.LoadScene("Exit Menu");
    }
}
