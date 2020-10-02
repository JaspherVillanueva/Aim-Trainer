using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateEnemies : MonoBehaviour
{
    public int maxEnemies = 10;
    public int xPos;
    public int zPos;
    public int yPos = 1;
    public int enemyCount = 0;
    public GameObject theTarget;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    IEnumerator EnemyDrop()
    {
        while (enemyCount < maxEnemies)
        {
            xPos = Random.Range(30, 50);
            zPos = Random.Range(-10, -40);
            SpawnTarget();
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }

    public void SpawnTarget()
    {
        Instantiate(theTarget, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }

    public void SpawnMultipleTargets()
    {
        xPos = Random.Range(30, 50);
        zPos = Random.Range(-10, -40);
        SpawnTarget();
        enemyCount += 1;
    }
}
