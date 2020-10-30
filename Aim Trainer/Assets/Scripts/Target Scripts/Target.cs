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
    public float health = 50f;                                                 //instantiating variables
    public int TargetScore = 10;
    public GameObject target;
    public int EnemyDistance;

    private GenerateEnemies Generator;
    private String sceneName;

    public Transform center;
    public Transform Bot1;

    public float rotationSpeed;
    public float speed;

    private Quaternion qTo;

    private int isRunning = 1;

    private Vector3 v3 = new Vector3(2, 13, 0);

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();                      //get the active scene
        sceneName = currentScene.name;
        Generator = GameObject.FindWithTag("EnemyGenerate").GetComponent<GenerateEnemies>();
        if (GenerateEnemies.Rotating == true)
        {
            rotationSpeed = 25f;
            speed = 10;
            rotationSpeed = BotDifficulty.botRotationSpeed;
            speed = BotDifficulty.botSpeed;
        }
    }

    private void Update()
    {
        if (GenerateEnemies.Rotating == true)
        {
            if (Bot1 != null)
            {
                center.transform.RotateAround
                    (center.position, Vector3.up, rotationSpeed * Time.deltaTime * 0.5f); //turning point
                Debug.Log("Moving around");
                if (isRunning == 1)
                {
                    StartCoroutine(Move());
                }
                Bot1.transform.localPosition = Vector3.MoveTowards
                    (Bot1.localPosition, v3, speed * Time.deltaTime);          //move the target closer and futrther from the center randomly
                Debug.Log("Moving yaxis");
            }
            else
            {
                Debug.Log("Bot1 Not Set");
            }
        }  
    }

    public IEnumerator Move()                                                   //Generates vector for target to move up and down
    {
        isRunning = 0;
        yield return new WaitForSeconds(2f);
        v3 = new Vector3(2, -RandomN(), 0);
        isRunning = 1;
    }

    public float RandomN()                                                       //Generate Random number
    {
        float position = Random.Range(13f, 40f);
        return position;
    }

    public void TakeDamage (float damage)                                        //when target is shot by player
    {                                                                            //target will take damage until it reaches 0
        GameManager.TargetsHit++;
        health -= damage;                                                        //decrease health

        if (health <= 0f)                                                        //if health below 0
        {
            Die();                                                               //die...
        }
    }
    
    void Die()                                                                    //when target health reaches 0
    {                                                                             //function is called to destroy the object
                                                                                  //and adds a score to the total score
        if (GenerateEnemies.Respawnable == false)                                 //as the object is destroyed it is replaced with a new target
        {
            ScoreScript.scoreValue += TargetScore;                                //add score  
        }

        if (sceneName == "The Ring" && GenerateEnemies.Rotating == true)
        {
            return;                                                               //spawn enemy in circle
        }

        Destroy(target);                                                           //remove object
        Debug.Log("Target Destroyed");                                             //debug log

        if (sceneName == "The Ring" && GenerateEnemies.Rotating == false)          //used to detect which map user has chosen
        {                                                                          //in order to spawn targets in the right place
            Generator.SpawnSingleCircularTarget(EnemyDistance);                    //spawn enemy in circle
        }

        else if (sceneName == "Stair Master" && GenerateEnemies.Respawnable == false)
        {
            int randomRow = Random.Range(0, 2);                                    //spawn a target on either row
            Generator.SpawnSingleStairTarget(EnemyDistance, randomRow);
        }
        else if (sceneName == "Stair Master" && GenerateEnemies.Respawnable == true)
        {
            Generator.SpawnRespawnableEnemy();
            Generator.ResetTimer();
            ScoreScript.scoreValue += 10;
        }
        else if (sceneName == "The Ring 2" && GenerateEnemies.Respawnable == false)
        {
            Debug.Log("No need to spawn");
        }
        else
        {
            Debug.Log("Failed To Find Scene");                                      //couldnt find the active scene
        }
    }
}