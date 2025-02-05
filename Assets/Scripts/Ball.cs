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
    private BallCounter ballCounter;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        ballCounter = GameObject.Find("SceneManager").GetComponent<BallCounter>();
        ballCounter.AddBall(gameObject);
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
            transform.position = new Vector3(player.transform.position.x,
                player.transform.position.y + player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y + diameter / 2 + 0.05f);
            if(Input.GetButton("Fire1"))
                SendIt();
        }

        if (transform.position.y <= -5)
        {
            KillBall();
        }
        
        if (Math.Abs(rb.velocity.x) < 0.05f)
        {
            if(Random.Range(1,2) == 1)
                rb.velocity = new Vector2(0.05f, rb.velocity.y).normalized * speed;
            else
                rb.velocity = new Vector2(-0.05f, rb.velocity.y).normalized * speed;
        }
        if (Math.Abs(rb.velocity.y) < 0.05f)
        {
            rb.velocity = new Vector2(rb.velocity.x, -0.05f).normalized * speed;
        }
    }

    public void SendIt()
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
        }
        
        if (col.gameObject.CompareTag("Brick"))
        {
            if (col.gameObject.TryGetComponent<Brick>(out Brick brick))
            {
                brick.TakeDamage(damage);
            }
        }
        
        audioSource.Play();
    }

    public void FixBallTransformValues()
    {
        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            rb.velocity = Vector2.zero;
            transform.localScale = new Vector3(diameter, diameter);
            transform.position = new Vector3(player.transform.position.x,
                player.transform.position.y + player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y + diameter / 2 + 0.05f);
        }
    }

    private void KillBall()
    {
        ballCounter.RemoveBall(gameObject);
        Destroy(gameObject);
    }
    
}
