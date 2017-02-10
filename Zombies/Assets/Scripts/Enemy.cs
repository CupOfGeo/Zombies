using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    float health = 2;
    public GameObject enemy;

    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    void Move()
    {
        
    }

    public void Damage(float dmg)
    {
        health -= dmg;
    }

    void Die()
    {
        Destroy(enemy);
    }
}
