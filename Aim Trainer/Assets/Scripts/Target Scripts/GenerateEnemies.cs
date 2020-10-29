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
    public static bool Respawnable = false;
    public static bool Rotating = false;


    public int CloseEnemies = 3;
    public int MidEnemies = 3;
    public int FarEnemies = 3;

    public GameObject closeTarget_Obj;
    public GameObject midTarget_Obj;
    public GameObject farTarget_Obj;

    public GameObject Bot1;

    public static float closeTarget_radius = 20.0f;
    public static float midTarget_radius = 30.0f;
    public static float farTarget_radius = 40.0f;

    private int xPos;
    private int zPos;
    private int yPos = 1;
    private Vector3 Center = new Vector3(50, 5, -50);
    private int enemyCount;
    private String sceneName;
    /*
     * RESPAWNING VARIABLES
     */

    public enum SpawnState { SPAWNING, WAITING};
    private GameObject LastSpawnedTarget;

    public float timeBetweenWaves;

    private float searchCountDown;
    public float waveTime;
    private SpawnState state = SpawnState.WAITING;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        timeBetweenWaves = GameDifficulty.waveTimer;
        Debug.Log(timeBetweenWaves);
        sceneName = currentScene.name;
        waveTime = timeBetweenWaves;
        searchCountDown = timeBetweenWaves;

       
        if (sceneName == "The Ring" && Rotating == false)
        {
            //Vector3 Center = new Vector3(50, 5, -50);
            //spawn close ring of enemies
            StartCoroutine(SpawnCircleOfEnemies(CloseEnemies, Center, closeTarget_Obj, closeTarget_radius));
            //spawn mid ring of enemies
            StartCoroutine(SpawnCircleOfEnemies(MidEnemies, Center, midTarget_Obj, midTarget_radius));
            //spawn far ring of enemies
            StartCoroutine(SpawnCircleOfEnemies(FarEnemies, Center, farTarget_Obj, farTarget_radius));
        }

        else if (sceneName == "The Ring" && Rotating == true)
        { 

        }

        else if (sceneName == "Stair Master" && Respawnable == false)
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

        else if (sceneName == "Stair Master 2")
        {
            Respawnable = true;
            SpawnRespawnableEnemy();
        }

        else
        {
            Debug.Log("you are not in aim trainer");
        }
    }

    void Update()
    {
        if (Respawnable)
        {
            waveTime -= Time.deltaTime;
            if (!EnemyIsAlive())
            {
                SpawnRespawnableEnemy();
                ResetTimer();
                //Debug.Log("Reset Timer");
            }

            if (waveTime <= 0f)
            {
                //Debug.Log(state);
                if (state == SpawnState.WAITING)
                {
                    //Check if Enemies Still Alive
                    if (EnemyIsAlive())
                    {
                        Debug.Log("Enemies Are Alive");
                        //Debug.Log(LastSpawnedTarget);
                        Destroy(LastSpawnedTarget);
                        SpawnRespawnableEnemy();
                    }
                }
                //DestroyEnemy();
                ResetTimer();
            }  
        }
    }

    public void ResetTimer()
    {
        waveTime = timeBetweenWaves;
    }

    public bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {

            if (GameObject.FindGameObjectsWithTag("CloseTarget").Length == 1
            && GameObject.FindGameObjectsWithTag("MidTarget").Length == 1
            && GameObject.FindGameObjectsWithTag("FarTarget").Length == 1)
            {
                return false;
            }
            searchCountDown = timeBetweenWaves;
        }
        return true;
    }

    IEnumerator SpawnEnemy()
    {
        state = SpawnState.SPAWNING;
        yield return new WaitForSeconds(1f);
        //spawn
        Debug.Log("Spawn an enemy");
        SpawnRespawnableEnemy();

        state = SpawnState.WAITING;

        yield break;
    }

    public void SpawnRespawnableEnemy()
    {
        int RandomTarget = Random.Range(1, 4);
        int RandomRow = Random.Range(0, 1);

        LastSpawnedTarget = SpawnSingleStairTarget(RandomTarget, RandomRow);
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
    public GameObject SpawnSingleStairTarget(int gameObj, int randomRow)
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
        GameObject LastSpawnedTarget = GameObject.Instantiate(targetSpawned, new Vector3(xPos, yPos, zPos), Quaternion.identity);
        //Debug.Log(LastSpawnedTarget);
        //Debug.Log("Spawned a new enemy");
        return LastSpawnedTarget;
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
