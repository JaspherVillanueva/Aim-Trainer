using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using System;
/*
 * This class is used to instatiate 
 * Targets for the player to shoot
 * Targets either take damage,
 * or they die due to no more health
 */
public class Target : MonoBehaviour
{
    //instantiating variables
    public float respawnDelay = 5f;
    public float health = 50f;
    public int TargetScore = 10;
    public GameObject target;
    public int EnemyDistance;

    private GenerateEnemies Generator;
    private String sceneName;
    private int isRunning = 1;

    private void Start()
    {
        //get the active scene
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Generator = GameObject.FindWithTag("EnemyGenerate").GetComponent<GenerateEnemies>();
    }

    //when target is shot by player
    //target will take damage until it reaches 0
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

    private void Update()
    {
        if(isRunning == 1)
        {
            if (sceneName == "Stair Master" && GenerateEnemies.Respawnable == true)
            {
                    StartCoroutine(DieRespawn());
                //Debug.Log("You in Da Scene");
                /*
                Debug.Log(GameObject.FindGameObjectsWithTag("CloseTarget").Length);
                if (GameObject.FindGameObjectsWithTag("CloseTarget").Length == 2 ||
                    GameObject.FindGameObjectsWithTag("MidTarget").Length == 2 ||
                    GameObject.FindGameObjectsWithTag("FarTarget").Length == 2)
                {
                }
                */
            }
        }
    }

    public IEnumerator DieRespawn()
    {
        isRunning = 0;
        yield return new WaitForSeconds(respawnDelay);
        //remove object
        Debug.Log(gameObject);
        Debug.Log(target);

        Destroy(gameObject);
        Destroy(target);
        Debug.Log("Destroyed Respawn Object");


        int RandomTarget = Random.Range(1, 3);
        int RandomRow = Random.Range(0, 1);
        Debug.Log(RandomTarget + " " +RandomRow);

        Generator.SpawnSingleStairTarget(RandomTarget, RandomRow);

        isRunning = 1;
    }

    //when target health reaches 0
    //function is called to destroy the object
    //and adds a score to the total score
    //as the object is destroyed it is replaced with a new target
    void Die()
    {
        //add score
        ScoreScript.scoreValue += TargetScore;

        //remove object
        Destroy(gameObject);
        Destroy(target);

        //get the active scene
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        //get the enemy generation script
        Generator = GameObject.FindWithTag("EnemyGenerate").GetComponent<GenerateEnemies>();

        //used to detect which map user has chosen
        //in order to spawn targets in the right place
        if (sceneName == "The Ring")
        {
            //spawn enemy in circle
            Generator.SpawnSingleCircularTarget(EnemyDistance);
        }
        else if (sceneName == "Stair Master" && GenerateEnemies.Respawnable == false)
        {
            //spawn a target on either row
            int randomRow = Random.Range(0, 2);
            Generator.SpawnSingleStairTarget(EnemyDistance, randomRow);
        }
        else if (sceneName == "Stair Master" && GenerateEnemies.Respawnable == true)
        {
            Debug.Log("ALLOCATE POINTS");
        }
        else
        {
            //couldnt find the active scene
            Debug.Log("Failed To Find Scene");
        }
        //debug log
        Debug.Log("Target Destroyed");
    }
}