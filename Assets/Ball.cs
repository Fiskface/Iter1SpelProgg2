using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool sent = false;
    private float speed = 1;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        if (!sent)
        {
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
        direction = Vector3.Reflect(direction.normalized, col.contacts[0].normal);
    }
}
