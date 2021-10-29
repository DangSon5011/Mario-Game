using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Player player;
    public Rigidbody2D r2d;
    public float speed=0f,khoangcach,h;
    Vector3 move;
    public bool check = false, barie=false;
    public BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        r2d = gameObject.GetComponent<Rigidbody2D>();
        box = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (player.transform.position.x > transform.position.x - khoangcach)
        {
            r2d.bodyType = RigidbodyType2D.Kinematic;
            check = true;
           
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
       if(check==true)
        {
            this.transform.position += new Vector3(0, speed, 0);
            r2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
       if ( barie==true)
        {
            this.transform.position += new Vector3(speed*h, 0, 0);
            r2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.ourHealth = 0;
            player.a = transform.position.y;
        }
        if(collision.collider.CompareTag("ong nuoc"))
        {
            speed = speed * -1;
        }
    }

    
}
