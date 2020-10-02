using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class GenerateEnemies : MonoBehaviour
{
    public int CloseEnemies;
    public int MidEnemies;
    public int FarEnemies;
    public int xPos;
    public int zPos;
    public int yPos = 1;
    public int enemyCount;
    public GameObject closeTarget;
    public GameObject midTarget;
    public GameObject farTarget;

    // Start is called before the first frame update
    void Start()
    {
        //amount of targets for each range
        CloseEnemies = 3;
        MidEnemies = 3;
        FarEnemies = 3;

        //spawn close enemies
        StartCoroutine(EnemyDrop(CloseEnemies, 20, closeTarget));
        Debug.Log("Close Enemies Spawned: " + CloseEnemies);

        //spawn mid enemies
        StartCoroutine(EnemyDrop(MidEnemies, 30, midTarget));
        Debug.Log("Mid Enemies Spawned: " + MidEnemies);

        //spawn far enemies
        StartCoroutine(EnemyDrop(FarEnemies, 40, farTarget));
        Debug.Log("Far Enemies Spawned" + FarEnemies);
    }

    // Update is called once per frame
    IEnumerator EnemyDrop(int maxEnemies, int Xposition, GameObject Target)
    {
        //check to see the number of enemies and the position of it
        Debug.Log(maxEnemies + " " + Xposition);

        //while enemy count <= maxEnemy
        for(int enemyCount = 1; enemyCount <= maxEnemies; enemyCount++)
        {
            //x= 30, 50
            //y= -10, -40

            //generate x axis
            xPos = Random.Range(Xposition, Xposition);
            //generate random range between 
            zPos = Random.Range(-10, -40);
            //spawn the object
            SpawnTarget(Target);
            yield return new WaitForSeconds(0.1f);
        }
    }

    //spawn the target
    public void SpawnTarget(GameObject Target)
    {
        //instatiate an object
        Instantiate(Target, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }

    public void SpawnMultipleTargets()
    {
        xPos = Random.Range(30, 50);
        zPos = Random.Range(-10, -40);
        //SpawnTarget();
        enemyCount += 1;
    }
}
