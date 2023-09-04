using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    public GameObject ball;
    public GameObject leftWall;
    public GameObject rightWall;

    private float minX;
    private float maxX;
    
    private void OnValidate()
    {
        ball.GetComponent<Ball>().FixBallTransformValues();
    }

    private void Awake()
    {
        RecalculateMinMaxPos();
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var newX = position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        newX = Mathf.Clamp(newX, minX, maxX);
        
        position = new Vector3(newX, position.y, position.z);
        transform.position = position;
    }

    public void RecalculateMinMaxPos()
    {
        var lossyScale = transform.lossyScale;
        minX = leftWall.transform.position.x + leftWall.transform.localScale.x / 2 + lossyScale.x / 2;
        maxX = rightWall.transform.position.x - rightWall.transform.localScale.x / 2 - lossyScale.x / 2;
    }
}
