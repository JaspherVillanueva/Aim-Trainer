﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class GenerateEnemies : MonoBehaviour
{

    public int CloseEnemies = 3;
    public int MidEnemies = 3;
    public int FarEnemies = 3;
    public int xPos;
    public int zPos;
    public int yPos = 1;
    public GameObject closeTarget_Obj;
    public GameObject midTarget_Obj;
    public GameObject farTarget_Obj;
    public int enemyCount;


    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        String sceneName = currentScene.name;

        if (sceneName == "Aim Trainer")
        {
            //spawn close enemies
            StartCoroutine(SpawnRowOfTargets(CloseEnemies, 20, closeTarget_Obj));
            //Debug.Log("Close Enemies Spawned: " + CloseEnemies);

            //spawn mid enemies
            StartCoroutine(SpawnRowOfTargets(MidEnemies, 30, midTarget_Obj));
            //Debug.Log("Mid Enemies Spawned: " + MidEnemies);

            //spawn far enemies
            StartCoroutine(SpawnRowOfTargets(FarEnemies, 40, farTarget_Obj));
            //Debug.Log("Far Enemies Spawned" + FarEnemies);
        }

        else if (sceneName == "The Ring")
        {
            Vector3 Center = new Vector3(50, 5, -50);
            //spawn close ring of enemies
            StartCoroutine(SpawnCircleOfEnemies(CloseEnemies, Center, closeTarget_Obj, 20.0f));
            //spawn mid ring of enemies
            StartCoroutine(SpawnCircleOfEnemies(MidEnemies, Center, midTarget_Obj, 30.0f));
            //spawn far ring of enemies
            StartCoroutine(SpawnCircleOfEnemies(FarEnemies, Center, farTarget_Obj, 40.0f));
        }

        else
        {
            Debug.Log("you are not in aim trainer");
        }
    }

    // Update is called once per frame
    IEnumerator SpawnRowOfTargets(int maxEnemies, int Xposition, GameObject Target)
    {
        //while enemy count <= maxEnemy
        for(int counter = 1; counter <= maxEnemies; counter++)
        {
            //generate x axis
            xPos = Random.Range(Xposition, Xposition);
            //generate random range between 
            zPos = Random.Range(-10, -40);
            //spawn the object
            enemyCount++;
            //Debug.Log(enemyCount);
            Instantiate(Target, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SpawnSingleTarget(int gameObj)
    {
        GameObject targetSpawned = null;

        if(gameObj == 1)
        {
            targetSpawned = closeTarget_Obj;
            xPos = 20;
        }
        else if(gameObj == 2)
        {
            targetSpawned = midTarget_Obj;
            xPos = 30;
        }
        else if (gameObj == 3)
        {
            targetSpawned = farTarget_Obj;
            xPos = 40;
        }
        else
        {
            Debug.Log("Error Spawn Target: Target Distance is not valid");
        }
        //generate random range between 
        zPos = Random.Range(-10, -40);
        Instantiate(targetSpawned, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }

    // Update is called once per frame
    IEnumerator SpawnCircleOfEnemies(int maxEnemies, Vector3 center, GameObject Target, float radius)
    {
        
        //while enemy count <= maxEnemy
        for (int counter = 1; counter <= maxEnemies; counter++)
        {
            Vector3 pos = RandomCircle(center, radius);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            //spawn the object
            //Debug.Log("LLOLOLOL");
            Instantiate(Target, pos, rot);
            enemyCount++;
            //Debug.Log(enemyCount);
            yield return new WaitForSeconds(0.1f);
        }
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

}
