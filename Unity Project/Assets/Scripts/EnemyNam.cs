using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNam : MonoBehaviour
{
    public float huong = 1f, speed, khoangcach, maxspeed = 2f, Toado_y;
    public bool killed = false, run = false, checkEnemy = false;
    public Rigidbody2D r2d_nam;
    public Player player;
    public Animator amin;
    public Collider2D attack, checkill;
    public Vector3 movp;
    public float fallgravity = 1000f;
    public float upgravity = 2f;
    public CircleCollider2D circle;
    // Start is called before the first frame update
    void Start()
    {
        r2d_nam = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        amin = gameObject.GetComponent<Animator>();



    }
    void Update()
    {
        amin.SetBool("Killed", killed);
        amin.SetBool("Run", run);
        if (player.transform.position.x > transform.position.x - khoangcach)
        {
            speed = maxspeed;

            if (r2d_nam.velocity.y < 0)
            {
                speed = 0f;
                r2d_nam.AddForce(new Vector2(0, -1000));
                //r2d_nam.velocity += Vector2.up * Physics2D.gravity.y * (fallgravity - 1) * Time.deltaTime;
                //r2d_nam.gravityScale = 1000;
            }

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        r2d_nam.velocity = new Vector2(speed * huong, 0);
        if (checkEnemy == true)
        {
            //  Toado_y = transform.position.y;
            //  freeze();
            r2d_nam.velocity = new Vector2(r2d_nam.velocity.x, 0);
            checkEnemy = false;
        }
        else
        {
            r2d_nam.velocity = new Vector2(speed * huong, 0);
        }
        
        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("ong nuoc")|| collision.collider.CompareTag("Brock"))
        {
            huong *= -1;

        }
        if (collision.collider.CompareTag("EnemyNam"))
        {
            circle.isTrigger = true;
            r2d_nam.bodyType = RigidbodyType2D.Kinematic;
            checkEnemy = true;
        }
        if(collision.collider.CompareTag("Mai rua"))
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyNam"))
        {
            circle.isTrigger = true;
            r2d_nam.bodyType = RigidbodyType2D.Kinematic;
            checkEnemy = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyNam"))
        {
            checkEnemy = false;
            circle.isTrigger = false;
            r2d_nam.bodyType = RigidbodyType2D.Dynamic;
        }
    }


}
