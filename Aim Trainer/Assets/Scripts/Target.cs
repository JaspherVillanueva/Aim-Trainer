using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private int TargetScore = 10;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        ScoreScript.scoreValue += TargetScore;
        Destroy(gameObject);
        Debug.Log("Target Destroyed");
    }
}
