using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateEnemies : MonoBehaviour
{
    public int maxEnemies = 5;
    public int xPos;
    public int zPos;
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
            xPos = Random.Range(-40, 80);
            zPos = Random.Range(-10, 40);
            Instantiate(theTarget, new Vector3(xPos, 2, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
