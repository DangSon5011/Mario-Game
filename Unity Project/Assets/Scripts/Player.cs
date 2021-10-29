using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxspeed = 2, jumpPow = 250f, vitri = 9, a,knockbackpow,knockupx,knockupy;
    public bool Grounded = true, faceRight = true, die = false, playerDie = false,Dich=false;
    public float timedelay = 50f;
    public int ourHealth;
    public int maxHealth = 5;
    public GameObject Maincamera;
    public Rigidbody2D r2;
    public Animator amin;
    public BoxCollider2D box;
    public SpriteRenderer Layer;
    private GameMaster gm;
    public int life;
    public AudioClip jump,kick;
    public AudioSource audiosrc;
    
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        box = gameObject.GetComponent<BoxCollider2D>();
        amin = gameObject.GetComponent<Animator>();
        Layer = gameObject.GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
        Maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        ourHealth = 1;
        
        life=PlayerPrefs.GetInt("life");

        jump = Resources.Load<AudioClip>("Jump");
        kick = Resources.Load<AudioClip>("Kich");
        audiosrc = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        amin.SetBool("Grounded", Grounded);
        amin.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        amin.SetBool("death", die);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            audiosrc.PlayOneShot(jump, 1f);
            if (Grounded)
            {
                Grounded = false;
                r2.AddForce(Vector2.up * jumpPow);
            }

        }
        
    }
    
    void FixedUpdate()
    {
        if (Dich==false)
        { 
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        if (h > 0 && !faceRight)
        {
            Flips();
        }
        if (h < 0 && faceRight)
        {
            Flips();
        }
        if (Grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }
    }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            
            
        }
        ////// chan khong di chuyen ve map cu//////
        if (transform.position.x <= (Maincamera.transform.position.x - vitri))
        {
            transform.position = new Vector2(Maincamera.transform.position.x - vitri, transform.position.y);
        }

        //// death khi mau bang 0////////
        if (ourHealth == 0)
        {
           
            death();
        }

        /////// death khi rời khỏi tầm nhìn của camera quá 2 s/////////
        {
            if (transform.position.y <= -24 || transform.position.y >= 24)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void Flips()
    {
        faceRight = !faceRight;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void death()
    {
        die = true;
        //  Time.timeScale = 0;
      
        r2.velocity = new Vector2(0, 6);
        if (transform.position.y < a + 1.5f)
        {
            box.isTrigger = true;
            Layer.sortingOrder = 3;
            this.tag= "Untagged";
        }
        else

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            life--;
            PlayerPrefs.SetInt("life", life);
          
        }

    }

    public void Knockup()
    {
        r2.AddForce(new Vector2(knockupx,knockupy));
    }
    public void Knockback()
    {
         r2.AddForce(new Vector2(0,knockbackpow));
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("EnemyNam"))
        {
            audiosrc.PlayOneShot(kick, 1f);
        }
    }

}
