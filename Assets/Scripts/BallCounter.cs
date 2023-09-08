using System;
using System.Collections;
using System.Collections.Generic;
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
            SpawnBall();
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
}
