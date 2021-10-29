using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoaanthit1 : MonoBehaviour
{
    public Player player;
    public Animator amin;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        amin = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            player.ourHealth = 0;
            player.a = transform.position.y;
        }
    }
}
