using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("SceneManager").GetComponent<BallCounter>().GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
