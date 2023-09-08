using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GunPU : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(weapon,other.transform.position,quaternion.identity,other.transform);
            Destroy(gameObject);
        }
    }
}
