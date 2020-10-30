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
    public float health = 0f;
    public int TargetScore = 10;
    public Transform center;
    public Transform target;


    public float rotationSpeed;
    public float speed;

    private Quaternion qTo;

    private int isRunning = 1;

    private Vector3 v3 = new Vector3(2,13,0);

    //when target is shot by player
    //target will take damage until it reaches 0

    void Start()
    {
        rotationSpeed = (float)BotDifficulty.botRotationSpeed;
        speed = (float)BotDifficulty.botSpeed;
    }


    public void TakeDamage(float damage)
    {
        GameManager.TargetsHit++;
        //decrease health
        health -= damage;
        //if health below 0
        ScoreScript.scoreValue += TargetScore;
        Debug.Log(health);
    }

    private void Update()
    {
        center.transform.RotateAround(center.position, Vector3.up, rotationSpeed * Time.deltaTime * 0.5f);
        if (isRunning == 1)
        {
            StartCoroutine(Move());
        }
        target.transform.localPosition = Vector3.MoveTowards(target.localPosition, v3, speed * Time.deltaTime);
    }

    public IEnumerator Move()
    {
        isRunning = 0;
        yield return new WaitForSeconds(2f);
        v3 = new Vector3(2, RandomN(), 0);

        isRunning = 1;
    }

    public float RandomN()
    {
        Wait(10f);
        float position = Random.Range(13f, 40f);
        return position;
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}