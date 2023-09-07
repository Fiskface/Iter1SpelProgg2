using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    private List<Ball> ballsActive;
    void Start()
    {
        ballsActive = new List<Ball>();
        EventManager.ballDeathEvent += removeBall;
        EventManager.ballSpawnedEvent += addBall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void removeBall(Ball ball)
    {
        ballsActive.Remove(ball);
    }

    private void addBall(Ball ball)
    {
        ballsActive.Add(ball);
    }
}
