using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 3;
    void Update()
    {
        if(Health <= 0)
        {
            Die();
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Health -= 1;
        }

        if (other.tag == "EndPoint")
        {
            ReachedTarget();
        }

    }

    void Die()
    {
        ScoreManager.Score += 1;
        Destroy(gameObject);
    }

    void ReachedTarget()
    {
        PlayerHealth.Health -= 1;
        Destroy(gameObject);
    }
}
