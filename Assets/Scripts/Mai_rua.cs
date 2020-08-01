using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mai_rua : MonoBehaviour
{
    public Player player;
    public float speed,maxspeed,khoangcach;
    public Rigidbody2D r2d;
    public bool right,left;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        r2d = gameObject.GetComponent<Rigidbody2D>();
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (r2d.velocity.y < 0)
        {
            speed = 0f;
            r2d.AddForce(new Vector2(0, -1000));

        }
    }
    void FixedUpdate()
    {
        if(right==true)
        {
            speed = maxspeed;
            r2d.velocity = new Vector2(speed, 0);
            if (r2d.velocity.y < 0)
            {
                speed = 0f;
                r2d.AddForce(new Vector2(0, -1000));

            }
        }
        if(left==true)
        {
            speed = maxspeed;
            r2d.velocity = new Vector2(-speed, 0);
            if (r2d.velocity.y < 0)
            {
                speed = 0f;
                r2d.AddForce(new Vector2(0, -1000));

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.CompareTag("Player"))
        {
            if(speed==0)
            {
                if(player.transform.position.x< this.transform.position.x+khoangcach)
                {
                    right = true;
                }
                else
                {
                    left = true;
                }
            }
            else
            {
                player.Knockback();
                player.a = this.transform.position.y;
                player.ourHealth = 0;
            }
        }
        
        if (collision.collider.CompareTag("ong nuoc"))
        {
            right = !right;
            left = !left;
        }
    }
}
