using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        position = new Vector3(position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime, position.y, position.z);
        transform.position = position;
    }
}
