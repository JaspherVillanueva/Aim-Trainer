using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int Score = 25;
    private int totalScore = 100;
    public bool ifDie = false;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        totalScore += Score;
        
    }
}
