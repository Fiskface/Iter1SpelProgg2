using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPU : MonoBehaviour
{
    [SerializeField] private GameObject typeOfBallThatSpawns;
    [SerializeField] private int amountOfBallsToSpawn;

    private BallCounter ballCounter;
    void Awake()
    {
        ballCounter = GameObject.Find("SceneManager").GetComponent<BallCounter>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ballCounter.BallPowerUp(amountOfBallsToSpawn, typeOfBallThatSpawns);
            Destroy(gameObject);
        }
    }
}
