using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;
using System;
using System.Security.Cryptography;
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
    private String sceneName;

    public Transform center;
    public Transform target1;

    public float rotationSpeed;
    public float speed;

    private Quaternion qTo;

    private int isRunning = 1;

    private Vector3 v3 = new Vector3(2, 13, 0);


    private void Start()
    {
        //get the active scene
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Generator = GameObject.FindWithTag("EnemyGenerate").GetComponent<GenerateEnemies>();
        if (GenerateEnemies.Rotating == true)
        {
            //rotationSpeed = BotDifficulty.botRotationSpeed;
            //speed = BotDifficulty.botSpeed;
        }
    }

    private void Update()
    {
        if (GenerateEnemies.Rotating == true)
        {
            //turning point
            center.transform.RotateAround(center.position, Vector3.up, rotationSpeed * Time.deltaTime * 0.5f);
            if (isRunning == 1)
            {
                StartCoroutine(Move());
            }
            //distance from center
            target1.transform.localPosition = Vector3.MoveTowards(target1.localPosition, v3, speed * Time.deltaTime);
        }
        
    }

    //Generates vector for target to move up and down
    public IEnumerator Move()
    {
        isRunning = 0;
        yield return new WaitForSeconds(2f);
        v3 = new Vector3(2, RandomN(), 0);
        isRunning = 1;
    }

    //Generate Random number
    public float RandomN()
    {
        float position = Random.Range(13f, 40f);
        return position;
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

    //when target health reaches 0
    //function is called to destroy the object
    //and adds a score to the total score
    //as the object is destroyed it is replaced with a new target
    void Die()
    {
        //add score
        if (GenerateEnemies.Respawnable == false)
        {
            ScoreScript.scoreValue += TargetScore;
        }

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
            Generator.SpawnRespawnableEnemy();
            Generator.ResetTimer();
            ScoreScript.scoreValue += 10;
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