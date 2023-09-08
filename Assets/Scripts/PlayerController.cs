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
    public SpriteRenderer sr;
    public BoxCollider2D bc;

    private float minX;
    private float maxX;
    
    private void OnValidate()
    {
        bc.size = sr.size;
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        RecalculateMinMaxPos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var position = transform.position;
        var newX = position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        newX = Mathf.Clamp(newX, minX, maxX);
        
        position = new Vector3(newX, position.y, position.z);
        transform.position = position;
    }

    public void RecalculateMinMaxPos()
    {
        var size = sr.size;
        minX = leftWall.transform.position.x + leftWall.transform.localScale.x / 2 + size.x / 2;
        maxX = rightWall.transform.position.x - rightWall.transform.localScale.x / 2 - size.x / 2;
        bc.size = size;
    }
}
