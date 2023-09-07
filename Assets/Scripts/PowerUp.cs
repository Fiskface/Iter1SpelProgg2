using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField, Tooltip("The speed that powerups move down before being picked up.")] private float speedDownwards = 1f;

    private void OnValidate()
    {
        if (speedDownwards <= 0)
        {
            Debug.LogWarning("Speed Downwards cannot be 0 or less!",this);
        }
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        var position = transform.position;
        position = new Vector3(position.x, position.y - speedDownwards * Time.deltaTime);
        transform.position = position;

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
