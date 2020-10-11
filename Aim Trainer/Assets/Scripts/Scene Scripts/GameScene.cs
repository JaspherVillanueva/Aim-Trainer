using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public void goToAimTrainer()
    {
        Debug.Log("Going to game scene");
        SceneManager.LoadScene("AimTrainer");
    }
}
