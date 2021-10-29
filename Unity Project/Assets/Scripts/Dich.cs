using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dich : MonoBehaviour
{
    public Player player;
   
    public bool check,check2,face,goal;
    Vector3 move;
    public float speed,khoangcach;
    public Animator amin;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
        move = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        if (check == true && check2 == false)
        {
            player.r2.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        }
        if (check == false && check2 == true)
        {

            player.r2.constraints = RigidbodyConstraints2D.FreezeRotation;

            player.r2.AddForce(new Vector2(speed, 0));
            player.r2.velocity = new Vector2(speed, 0);
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            player.Dich = true;
            
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            check = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            check = false;
            check2 = true;
            player.Dich = true;

        }
    }




}
