﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkkill : MonoBehaviour
{
    public Player player;
    public GameObject nam;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            player.Knockback();
            
            player.a = transform.position.y+1;
            Destroy(nam.gameObject);
        
        }
    }
}
