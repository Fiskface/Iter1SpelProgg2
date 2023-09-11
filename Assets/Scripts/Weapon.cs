using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("How many seconds the powerup lives")] private float aliveTime = 10f;
    [SerializeField, Tooltip("How many seconds the powerup lives")] private float shootCooldown = 1f;
    private float currentAliveTime = 0;
    private float currentCooldown = 0;

    private List<Gun> gunComponents;

    private void OnValidate()
    {
        if (aliveTime < 1)
        {
            aliveTime = 1;
            Debug.LogWarning("It has to exist for at least 1 second");
        }
    }

    private void Awake()
    {
        currentAliveTime = aliveTime;
        gunComponents = new List<Gun>();
        foreach (var gun in gameObject.GetComponentsInChildren<Gun>())
        {
            gunComponents.Add(gun);
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        currentAliveTime -= Time.deltaTime;
        currentCooldown -= Time.deltaTime;
        if (currentAliveTime <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetButton("Fire1"))
        {
            TryShoot();
        }
    }

    private void TryShoot()
    {
        if(StaticValues.lives > 0)
        {
            if (currentCooldown <= 0)
            {
                currentCooldown = shootCooldown;
                foreach (var gun in gunComponents)
                {
                    gun.Shoot();
                }
            }
        }
    }

    public void RefreshTime()
    {
        currentAliveTime = aliveTime;
    }
    
    public void OnDrawGizmos(){
        foreach (var gun in GetComponentsInChildren<Gun>())
        {
            Vector3 from = gun.transform.TransformPoint(Vector3.zero);
            Vector3 to = gun.transform.TransformPoint(Vector3.up);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(from, to);
        }
        
    }
}
