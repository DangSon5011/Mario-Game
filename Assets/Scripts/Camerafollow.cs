﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public float smoothtimeX, smoothtimeY,vitri;
    public Vector2 velocity;

    public GameObject player;
    public Vector2 minpos, maxpos;
    public bool bound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.x <= player.transform.position.x)
        {
            float posx = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
            float posy = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
            transform.position = new Vector3(posx, posy, transform.position.z);
        }
       else if (transform.position.x > player.transform.position.x)
        {
            float posy = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
            transform.position = new Vector3(transform.position.x, posy, transform.position.z);
        }
        if (bound)
        {
                
         transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x, maxpos.x),
                                                 Mathf.Clamp(transform.position.y, minpos.y, maxpos.y),
                                                 Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        }
        
    }
}
