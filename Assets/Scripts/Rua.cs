using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rua : MonoBehaviour
{
    public float huong = 1f, speed, khoangcach, maxspeed = 2f;
    public bool killed = false, run = false, checkEnemy = false, faceRight = true;
    public Rigidbody2D r2d_nam;
    public Player player;
    public Animator amin;
    public Vector3 movp;
    public CapsuleCollider2D circle;
    public GameObject Mai_rua;
    // Start is called before the first frame update
    void Start()
    {
        r2d_nam = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        amin = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > transform.position.x - khoangcach)
        {
            speed = maxspeed;

            if (r2d_nam.velocity.y < 0)
            {
                speed = 0f;
                r2d_nam.AddForce(new Vector2(0, -1000));

            }

        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (huong > 0 && !faceRight)
        {
            Flips();
        }
        if (huong < 0 && faceRight)
        {
            Flips();
        }


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
        ///killed////
        if (killed == true)
        {
            speed = 0;


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("ong nuoc"))
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
            Die();
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
    void Flips()
    {
        Vector3 scale;
        scale = transform.localScale;
        if (killed == false)
        {
            faceRight = !faceRight;

            scale.x *= -1;
            transform.localScale = scale;
        }
        else
        {
            scale.x = 1;
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
        Instantiate(Mai_rua, transform.position, transform.rotation);
    }
    
}
