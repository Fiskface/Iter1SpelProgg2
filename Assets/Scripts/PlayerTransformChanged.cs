using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerTransformChanged : MonoBehaviour
{
    void Awake()
    {
        if(Application.isPlaying)
            Destroy(this);
    }

    void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            if (transform.hasChanged)
            {
                GameObject ball = GameObject.FindWithTag("Ball");
                if (ball != null)
                   ball.GetComponent<Ball>().FixBallTransformValues();
            }
        }
    }
}

