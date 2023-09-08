using System;
using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool sent = false;
    private GameObject player = null;
    [SerializeField, Tooltip("The speed of the ball(s) (Must be non-negative)")] private float speed = 1;
    [SerializeField, Tooltip("The damage of the ball(s)")] private int damage = 1;
    [SerializeField, Tooltip("The diameter of the ball(s) (Must be non-negative)")] private float diameter;
    public Rigidbody2D rb;
    private BallCounter ballcounter;

    private void Start()
    {
        rb.velocity = Vector2.zero;
        player = GameObject.FindWithTag("Player");
        ballcounter = GameObject.Find("SceneManager").GetComponent<BallCounter>();
        ballcounter.AddBall(gameObject);
    }

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
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(player.transform.position.x, transform.position.y);
            if(Input.GetButton("Fire1"))
                SendIt();
        }

        if (transform.position.y <= -5)
        {
            KillBall();
        }
    }

    private void SendIt()
    {
        sent = true;
        Vector3 direction = new Vector3(Random.Range(-2f,2f), Random.Range(0.5f,2f), 0).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var newDir = transform.position - player.transform.position;
            newDir += new Vector3(0, 0.15f);
            newDir = newDir.normalized;
            rb.velocity = newDir * speed;
            
            return;
        }
        
        if (col.gameObject.CompareTag("Brick"))
        {
            if (col.gameObject.TryGetComponent<Brick>(out Brick brick))
            {
                brick.TakeDamage(damage);
            }
        }
    }

    public void FixBallTransformValues()
    {
        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            transform.localScale = new Vector3(diameter, diameter);
            transform.position = new Vector3(player.transform.position.x,
                player.transform.position.y + player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y + diameter / 2);
        }
    }

    private void KillBall()
    {
        ballcounter.RemoveBall(gameObject);
        Destroy(gameObject);
    }
}
