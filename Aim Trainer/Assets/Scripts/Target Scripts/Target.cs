using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using System;

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
        GameManager.TargetsHit++;
        //decrease health
        health -= damage;
        //if health below 0
        if (health <= 0f)
        {
            //die...
            Die();
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

        //Generator = GameObject.Find("EnemyGenerate").GetComponent<GenerateEnemies>();
        Generator = GameObject.FindWithTag("EnemyGenerate").GetComponent<GenerateEnemies>();

        if (sceneName == "The Ring")
        {
            //Debug.Log("THE RING HAS RESPAWNED A TARGET!!!");
            Generator.SpawnSingleCircularTarget(EnemyDistance);
        }

        else if (sceneName == "Stair Master")
        {
            int randomRow = Random.Range(0, 2);
            Debug.Log("STAIR MASTER!!!");
            Debug.Log("Random Range: " + randomRow);
            Generator.SpawnSingleStairTarget(EnemyDistance, randomRow);
        }

        /*
        Generator.SpawnSingleTarget(EnemyDistance);
        */
        //debug log
        Debug.Log("Target Destroyed");
    }


}

//spawn close enemies
StartCoroutine(SpawnRowOfTargets(CloseEnemies, 26, 104, closeTarget_Obj));
StartCoroutine(SpawnRowOfTargets(CloseEnemies, 28, 104, closeTarget_Obj));
//Debug.Log("Close Enemies Spawned: " + CloseEnemies);

//spawn mid enemies
StartCoroutine(SpawnRowOfTargets(MidEnemies, 34, 106, midTarget_Obj));
StartCoroutine(SpawnRowOfTargets(MidEnemies, 36, 106, midTarget_Obj));
//Debug.Log("Mid Enemies Spawned: " + MidEnemies);

//spawn far enemies
StartCoroutine(SpawnRowOfTargets(FarEnemies, 42, 107, farTarget_Obj));
StartCoroutine(SpawnRowOfTargets(FarEnemies, 44, 108, farTarget_Obj));