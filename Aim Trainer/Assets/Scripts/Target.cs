<<<<<<< HEAD
﻿using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
=======
﻿using UnityEngine;
>>>>>>> origin/Prashil

public class Target : MonoBehaviour
{
    public float health = 50f;
<<<<<<< HEAD
    private int TargetScore = 10;

    public void TakeDamage (float amount)
=======
    public int Score = 25;
    private int totalScore = 100;
    public bool ifDie = false;

    public void TakeDamage(float amount)
>>>>>>> origin/Prashil
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
<<<<<<< HEAD

    void Die()
    {
        ScoreScript.scoreValue += TargetScore;
        Destroy(gameObject);
        Debug.Log("Target Destroyed");
=======
    void Die()
    {
        Destroy(gameObject);
        totalScore += Score;
        
>>>>>>> origin/Prashil
    }
}
