using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Namgreen : MonoBehaviour
{
    public Rigidbody2D r2d;
    public float speed,h,maxspeed;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        r2d = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
        h = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if( r2d.velocity.y <0)
        {
            speed = 0f;
            r2d.AddForce(new Vector2(0, -500));
        }
        else
        {
            speed = maxspeed;
        }
            
    }
    void FixedUpdate()
    {
        r2d.velocity = new Vector2(speed * h, 0) ;   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.transform.localScale = new Vector3(player.transform.localScale.x * 2, player.transform.localScale.y * 2, player.transform.localScale.z * 2);
            player.tag = "khong lo";
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("ong nuoc"))
        {
            h = h * -1;
        }
        if(collision.collider.CompareTag("EnemyNam"))
        {
            Destroy(gameObject);
        }
    }

}
