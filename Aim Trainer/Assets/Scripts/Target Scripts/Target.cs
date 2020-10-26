using System.CodeDom.Compiler;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int TargetScore = 10;
    public GameObject target;
    public int EnemyCounter;
    public GenerateEnemies Generator;
    public int EnemyDistance;

    public void TakeDamage (float damage)
    {
        //decrease health
        health -= damage;
        //if health below 0
        if (health <= 0f)
        {
            //die...
            Die();
            Debug.Log("Die Function Called?");
        }
    }

    //when die
    void Die()
    {
        //add score
        ScoreScript.scoreValue += TargetScore;

        //remove object
        Destroy(gameObject);
        Destroy(target);

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "The Ring")
        {
            Generator = GameObject.Find("EnemyGenerate").GetComponent<GenerateEnemies>();
            Generator.SpawnSingleTarget(EnemyDistance);
            Debug.Log("THE RING HAS RESPAWNED A TARGET!!!");
        }

        /*
        Generator = GameObject.Find("EnemyGenerate").GetComponent<GenerateEnemies>();
        Generator.SpawnSingleTarget(EnemyDistance);
        */
        //debug log
        Debug.Log("Target Destroyed");
    }


}
