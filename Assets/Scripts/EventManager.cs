using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void BallSpawnedEvent(Ball ball);

    public static event BallSpawnedEvent ballSpawnedEvent;

    public delegate void BallDeathEvent(Ball ball);

    public static event BallDeathEvent ballDeathEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
