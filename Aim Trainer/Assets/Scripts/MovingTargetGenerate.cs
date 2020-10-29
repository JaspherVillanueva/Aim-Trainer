using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class MovingTargetGenerate : MonoBehaviour
{
    public int CloseEnemies = 1;

    public GameObject closeTarget_Obj;

    public static float closeTarget_radius = 20.0f;

    private int xPos;
    private int zPos;
    private int yPos = 1;
    private Vector3 Center = new Vector3(50, 5, -50);
    private int enemyCount;
    private String sceneName;

    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(SpawnCircleOfEnemies(CloseEnemies, Center, closeTarget_Obj, closeTarget_radius));
    }


    IEnumerator SpawnCircleOfEnemies(int maxEnemies, Vector3 center, GameObject Target, float radius)
    {
        //while enemy count <= maxEnemy
        for (int counter = 1; counter <= maxEnemies; counter++)
        {
            Vector3 pos = RandomCircle(center, radius);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            //spawn the object
            Instantiate(Target, pos, rot);
            enemyCount++;
            yield return new WaitForSeconds(0.1f);
        }
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
