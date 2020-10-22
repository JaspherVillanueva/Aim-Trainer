using System.CodeDom.Compiler;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int TargetScore = 10;
    public GameObject target;
    public int EnemyCounter;
    public GenerateEnemies Generator;
    public int EnemyDistance;

    //void Start()
    //{
    //    int random = Generator.enemyCount++;
    //    Debug.Log(random);
    //}

    public void TakeDamage (float damage)
    {
        //decrease health
        health -= damage;
        //if health below 0
        if (health <= 0f)
        {
            //die...
            Die();
        }
    }

    //when die
    void Die()
    {
        //add score
        ScoreScript.scoreValue += TargetScore;

        //remove object
        Destroy(gameObject);
        Destroy(target);

        Generator = GameObject.Find("EnemyGenerate").GetComponent<GenerateEnemies>();
        Generator.SpawnTarget(EnemyDistance);
        //debug log
        Debug.Log("Target Destroyed");
    }


}
