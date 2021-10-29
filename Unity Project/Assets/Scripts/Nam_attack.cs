using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nam_attack : MonoBehaviour
{
    public Player player;
    
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
        if ( collision.CompareTag("Player"))
        {
            player.a = transform.position.y;
            player.ourHealth = 0;

        }

    }
}


