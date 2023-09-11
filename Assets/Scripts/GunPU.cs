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
            if(other.transform.childCount == 0)
            {
                Instantiate(weapon, other.transform.position, quaternion.identity, other.transform);
            }
            else
            {
                other.transform.GetChild(0).GetComponent<Weapon>().RefreshTime();
            }
            Destroy(gameObject);
        }
    }
}
