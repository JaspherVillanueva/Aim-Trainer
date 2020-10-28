using System;
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

    public GameObject closeTarget_Obj;
    public GameObject midTarget_Obj;
    public GameObject farTarget_Obj;

    public static float closeTarget_radius = 20.0f;
    public static float midTarget_radius = 30.0f;
    public static float farTarget_radius = 40.0f;

    private int xPos;
    private int zPos;
    private int yPos = 1;
    private Vector3 Center = new Vector3(50, 5, -50);
    private int enemyCount;

    private Target TargetScript;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        String sceneName = currentScene.name;

        if (sceneName == "The Ring")
        {
            //Vector3 Center = new Vector3(50, 5, -50);
            //spawn close ring of enemies
            StartCoroutine(SpawnCircleOfEnemies(CloseEnemies, Center, closeTarget_Obj, closeTarget_radius));
            //spawn mid ring of enemies
            StartCoroutine(SpawnCircleOfEnemies(MidEnemies, Center, midTarget_Obj, midTarget_radius));
            //spawn far ring of enemies
            StartCoroutine(SpawnCircleOfEnemies(FarEnemies, Center, farTarget_Obj, farTarget_radius));
        }

        else if (sceneName == "Stair Master")
        {
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
            //Debug.Log("Far Enemies Spawned" + FarEnemies);
        }

        else if (sceneName == "Stairmaster2")
        {
            int randX = Random.Range(26, 44);
            int randY = Random.Range(104, 107);
            int randTarget = Random.Range(1, 3);

            if(randTarget == 1)
            {
                StartCoroutine(SpawnRowOfTargets(1, 26, 104, closeTarget_Obj));
                Debug.Log("Close target spawned");
            }
            else if(randTarget == 2)
            {
                StartCoroutine(SpawnRowOfTargets(1, 34, 106, midTarget_Obj));
                Debug.Log("Mid Target spawned");
            }
            else if (randTarget == 3)
            {
                StartCoroutine(SpawnRowOfTargets(1, 42, 108, farTarget_Obj));
                Debug.Log("Far Target spawnedS");
            }
            TargetScript = GameObject.FindWithTag("CloseTarget").GetComponent<Target>();
            TargetScript.Wait(5000);
            Debug.Log("Waited for 5000 seconds");
            TargetScript.TakeDamage(100);
            Debug.Log("Die Function Called in generate");
        }


        else
        {
            Debug.Log("you are not in aim trainer");
        }
    }

    // Update is called once per frame
    IEnumerator SpawnRowOfTargets(int maxEnemies, int Xposition, int Yposition, GameObject Target)
    {
        //while enemy count <= maxEnemy
        for (int counter = 1; counter <= maxEnemies; counter++)
        {
            //generate x axis
            xPos = Random.Range(Xposition, Xposition);
            //generate random range between 
            zPos = Random.Range(5, -40);
            //spawn the object
            enemyCount++;
            //Debug.Log(enemyCount);
            Instantiate(Target, new Vector3(xPos, Yposition, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    //used to repspawn targets from the stair map
    public void SpawnSingleStairTarget(int gameObj, int randomRow)
    {
        GameObject targetSpawned = null;

        if (gameObj == 1)
        {
            targetSpawned = closeTarget_Obj;
            if (randomRow == 0)
            {
                xPos = 26;
                yPos = 104;
            }
            else
            {
                xPos = 28;
                yPos = 104;
            }
        }
        else if (gameObj == 2)
        {
            targetSpawned = midTarget_Obj;
            if (randomRow == 0)
            {
                xPos = 34;
                yPos = 106;
            }
            else
            {
                xPos = 36;
                yPos = 106;
            }
        }
        else if (gameObj == 3)
        {
            targetSpawned = farTarget_Obj;
            if (randomRow == 0)
            {
                xPos = 42;
                yPos = 107;
            }
            else
            {
                xPos = 44;
                yPos = 108;
            }
        }
        else
        {
            Debug.Log("Error Spawn Target: Target Distance is not valid");
        }
        //generate random range between 
        zPos = Random.Range(5, -40);
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

    //Used to respawn target from the ring map
    public void SpawnSingleCircularTarget(int gameObj)
    {
        GameObject targetSpawned = null;
        float radius = 0.0f;

        if (gameObj == 1)
        {
            targetSpawned = closeTarget_Obj;
            radius = closeTarget_radius;
        }
        else if (gameObj == 2)
        {
            targetSpawned = midTarget_Obj;
            radius = midTarget_radius;
        }
        else if (gameObj == 3)
        {
            targetSpawned = farTarget_Obj;
            radius = farTarget_radius;
        }
        else
        {
            Debug.Log("Error Spawn Target: Target Distance is not valid");
        }
        Vector3 pos = RandomCircle(Center, radius);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, Center - pos);
        Instantiate(targetSpawned, pos, rot);
        //Debug.Log("SPAWNING SINGLE CIRCLE TARGET");
    }

    //used to get random vector from a circle
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
