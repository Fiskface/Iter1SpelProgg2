using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
    
    public void OnDrawGizmosSelected(){
        Gizmos.color = Color.white;
        Vector3 position = transform.TransformPoint(0.5f * Vector3.up);
        Gizmos.DrawSphere(position, 0.025f);
    }
}
