using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField, Tooltip("How much damage (how many hits) it takes for the brick to be destroyed")] private int health = 1;
    
    
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
