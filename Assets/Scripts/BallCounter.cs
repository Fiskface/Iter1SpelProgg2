using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    private List<Ball> ballsActive;
    [SerializeField] private GameObject defaultBall;

    private void Start()
    {
        ballsActive = new List<Ball>();
    }

    public void RemoveBall(Ball ball)
    {
        ballsActive.Remove(ball);
        if (ballsActive.Count == 0)
        {
            SpawnBall();
        }
    }

    public void AddBall(Ball ball)
    {
        ballsActive.Add(ball);
    }

    private void SpawnBall()
    {
        var newBall = Instantiate(defaultBall);
        newBall.GetComponent<Ball>().FixBallTransformValues();
    }
}
