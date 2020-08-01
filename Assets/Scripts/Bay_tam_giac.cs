using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bay_tam_giac : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            player.ourHealth = 0;
            player.a = transform.position.y;
        }
    }
}
