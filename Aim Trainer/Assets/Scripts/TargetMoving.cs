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
public class TargetMoving : MonoBehaviour
{
    //instantiating variables
    public float health = 50f;
    public int TargetScore = 10;
    public GameObject target;
    public int EnemyDistance;

    private MovingTargetGenerate Generator;
    private String sceneName;

    private Vector3 Center = new Vector3(50, 5, -50);

    private void Start()
    {
        //get the active scene
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Generator = GameObject.FindWithTag("EnemyGenerate").GetComponent<MovingTargetGenerate>();
    }

    //when target is shot by player
    //target will take damage until it reaches 0
    public void TakeDamage(float damage)
    {
        GameManager.TargetsHit++;
        //decrease health
        health -= damage;
        //if health below 0
        if (health <= 0f)
        {
            ScoreScript.scoreValue += TargetScore;
        }
    }

    private void Update()
    {
        Vector3 pos = RandomCircle(Center, 20f);
        
        target.transform.position += pos;

        Wait(1);
    }

    Vector3 RandomCircle(Vector3 Center, float radius)
    {
        float angle = Random.value * 360;
        Vector3 pos;
        pos.x = Center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.z = Center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.y = Center.y;
        return pos;
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}