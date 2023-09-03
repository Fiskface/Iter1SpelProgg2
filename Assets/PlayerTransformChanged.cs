using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerTransformChanged : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            if (transform.hasChanged)
            {
                gameObject.GetComponent<PlayerController>().ball.GetComponent<Ball>().FixBallTransformValues();
            }
        }
    }
}
