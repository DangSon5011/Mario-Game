﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
       /* if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);

        }*/
    }
}
