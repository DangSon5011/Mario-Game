using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconmario : MonoBehaviour
{
    public Rigidbody2D r2d;
    public Player player;
    public float speed,khoangcach;
    // Start is called before the first frame update
    void Start()
    {
        r2d = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.x >= transform.position.x - khoangcach)

        {
            r2d.velocity = new Vector2(speed, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.a = transform.position.y;
            player.ourHealth = 0;
        }
    }
}
