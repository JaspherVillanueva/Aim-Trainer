using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int TargetScore = 10;
    public GameObject target;

    public void TakeDamage (float amount)
    {
        //decrease health
        health -= amount;
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
        //debug log
        Debug.Log("Target Destroyed");
    }
}
