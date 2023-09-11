using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour
{
    [SerializeField, Tooltip("How much damage (how many hits) it takes for the brick to be destroyed")] private int health = 1;
    [SerializeField, Tooltip("How much score the brick gives when destroyed")] private int scoreValue = 10;
    [SerializeField, Tooltip("If the block can be destroyed or not")] private bool breakable = true;
    [SerializeField, Tooltip("It's 1 in x probability for a powerup to spawn when brick get's destroyed.")] private int powerUpProbability = 5;

    [SerializeField] private List<GameObject> PowerUps;
    private Animator animator;
    private GameObject myCamera;
    private BrickCounter brickCounter;

    private bool firstTimeDead = true;


    private void OnValidate()
    {
        if (powerUpProbability < 1)
        {
            powerUpProbability = 1;
            Debug.LogWarning("Probability has to be at least 1 in 1 (can't be less than 1)", this);
        }

        if (health < 1)
        {
            health = 1;
            Debug.LogWarning("Health has to be at least 1!", this);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        myCamera = GameObject.FindWithTag("MainCamera");
        brickCounter = GameObject.Find("SceneManager").GetComponent<BrickCounter>();
        if(breakable)
            brickCounter.BrickSpawned();
    }

    public void TakeDamage(int damage)
    {
        if (breakable)
        {
            health -= damage;
            CheckIfDead();
            animator.SetTrigger("Hit");
        }
    }

    private void CheckIfDead()
    {
        if(firstTimeDead)
        {
            if (health <= 0)
            {
                firstTimeDead = false;
                StaticValues.score += scoreValue;
                SpawnPowerUp();
                myCamera.GetComponent<Shake>().Shaker();
                brickCounter.BrickDestroyed();
                Destroy(gameObject);
            }
        }
    }

    private void SpawnPowerUp()
    {
        if (Random.Range(1, powerUpProbability) == 1)
        {
            Instantiate(PowerUps[Random.Range(0, PowerUps.Count)], transform.position, Quaternion.identity);
        }
    }
}
