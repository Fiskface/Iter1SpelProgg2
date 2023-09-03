using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    public GameObject ball;
    
    private void OnValidate()
    {
        ball.GetComponent<Ball>().FixBallTransformValues();
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        position = new Vector3(position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime, position.y, position.z);
        transform.position = position;
    }
}
