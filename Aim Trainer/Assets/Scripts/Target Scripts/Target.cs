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
    public float health = 50f;
    public int TargetScore = 10;
    public GameObject target;
    public int EnemyDistance;
    private GenerateEnemies Generator;

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
        else if (sceneName == "Stair Master")
        {
            //spawn a target on either row
            int randomRow = Random.Range(0, 2);
            Generator.SpawnSingleStairTarget(EnemyDistance, randomRow);
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