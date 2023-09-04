using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool sent = false;
    public GameObject player;
    [SerializeField, Tooltip("The speed of the ball(s) (Must be non-negative)")] private float speed = 1;
    private Vector3 direction;
    [SerializeField, Tooltip("The Diameter of the ball(s) (Must be non-negative)")] private float diameter;

    private void OnValidate()
    {
        if (speed < 0)
        {
            speed = 0;
            Debug.LogWarning("Speed of the ball must be non-negative!", this);
        }
        if (diameter < 0)
        {
            diameter = 0;
            Debug.LogWarning("Diameter of the ball must be non-negative!", this);
        }

        FixBallTransformValues();
    }


    void Update()
    {
        if (!sent)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y);
            if(Input.GetButton("Fire1"))
                SendIt();
        }
        else
        {
            transform.position += speed * Time.deltaTime * direction;
        }
    }

    private void SendIt()
    {
        transform.parent = null;
        sent = true;
        direction = new Vector3(1, 1, 0).normalized;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            var newDir = transform.position - player.transform.position;
            newDir += new Vector3(0, 0.15f);
            newDir = newDir.normalized;
            direction = newDir;
            return;
        }
        
        if (col.gameObject.CompareTag("Brick"))
        {
            if (col.gameObject.TryGetComponent<Brick>(out Brick brick))
            {
                brick.TakeDamage(1);
            }
        }
        
        direction = Vector3.Reflect(direction.normalized, col.contacts[0].normal);
    }

    public void FixBallTransformValues()
    {
        transform.localScale = new Vector3(diameter, diameter);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + player.transform.localScale.y / 2 + diameter / 2);
    }
}
