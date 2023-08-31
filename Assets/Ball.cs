using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool sent = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!sent)
            if(Input.GetButton("Fire1"))
                SendIt();
    }

    private void SendIt()
    {
        transform.parent = null;
        sent = true;
    }
}
