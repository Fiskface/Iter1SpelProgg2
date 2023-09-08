using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("How many seconds the powerup lives")] private float aliveTime = 10f;
    [SerializeField, Tooltip("How many seconds the powerup lives")] private float shootCooldown = 10f;

    private void OnValidate()
    {
        if (aliveTime < 1)
        {
            aliveTime = 1;
            Debug.LogWarning("It has to exist for at least 1 second");
        }
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= Time.deltaTime;
        shootCooldown -= Time.deltaTime;
        if (aliveTime <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetButton("Fire1"))
        {
            foreach (var gun in GetComponentsInChildren<Gun>())
            {
                gun.Shoot();
            }
        }
    }
}
