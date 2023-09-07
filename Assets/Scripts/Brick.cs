using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour
{
    [SerializeField, Tooltip("How much damage (how many hits) it takes for the brick to be destroyed")] private int health = 1;
    [SerializeField, Tooltip("If the block can be destroyed or not")] private bool Breakable = true;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (Breakable)
        {
            health -= damage;
            CheckIfDead();
            animator.SetTrigger("Hit");
        }
    }

    private void CheckIfDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void SpawnPowerUp()
    {
        Random.Range(1, 3);
        
    }
}
