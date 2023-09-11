using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    private List<GameObject> ballsActive;
    [SerializeField] private GameObject defaultBall;

    private void Awake()
    {
        ballsActive = new List<GameObject>();
    }

    public void RemoveBall(GameObject ball)
    {
        ballsActive.Remove(ball);
        if (ballsActive.Count == 0)
        {
            StaticValues.lives--;
            
            if (StaticValues.lives > 0)
            {
                SpawnBall();
            }
            else
            {
                foreach (Transform child in GameObject.Find("GameOverScreen").transform)
                {
                    child.GameObject().SetActive(true);
                }

                
            }
        }
    }

    public void AddBall(GameObject ball)
    {
        ballsActive.Add(ball);
    }

    private void SpawnBall()
    {
        var newBall = Instantiate(defaultBall);
        newBall.GetComponent<Ball>().FixBallTransformValues();
    }

    public void BallPowerUp(int amountToSpawn, GameObject typeOfBall)
    {
        for (int i = ballsActive.Count - 1; i >= 0 ; i--)
        {
            for (int j = 0; j < amountToSpawn; j++)
            {
                GameObject newBall = Instantiate(typeOfBall, ballsActive[i].transform.position, quaternion.identity);
                Ball ballScript = newBall.GetComponent<Ball>();
                ballScript.SendIt();
            }
        }
    }

    public void GameOver()
    {
        for (int i = ballsActive.Count - 1; i >= 0 ; i--)
        {
            Destroy(ballsActive[i]);
        }
        ballsActive.Clear();
    }
}
