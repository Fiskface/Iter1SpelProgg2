using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float speed = 3;

    private void OnValidate()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hej");
        if (other.CompareTag("Brick"))
        {
            other.GetComponent<Brick>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
