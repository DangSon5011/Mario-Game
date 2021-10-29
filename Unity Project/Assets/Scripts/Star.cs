using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Player player;
    public Rigidbody2D r2d;
    public float limit_tren, limit_duoi,limit_trai,limit_phai,powx,powy,h,u;
    public bool force=false;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        r2d = gameObject.GetComponent<Rigidbody2D>();
        move = this.transform.position;
    }
     void Update()
    {
        if (this.transform.position.x < limit_trai)
        {
            force = false;
        }
        else
        {
            force = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (force == true)

        {
            move.x += powx * h;
            move.y += powy * u;
            this.transform.position = move;
            if (this.transform.position.x >= limit_phai || this.transform.position.x <= limit_trai)
            {
                h *= -1;
               
            }
            if (this.transform.position.y >= limit_tren || this.transform.position.y <= limit_duoi)
            {
                u *= -1 ;
               
            }
        }
        else
        {
            move.x += 0.1f;
         
            this.transform.position = move;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            player.Knockback();
            player.a = transform.position.y + 1;
            player.ourHealth = 0;
        }
        
      
    }

}
