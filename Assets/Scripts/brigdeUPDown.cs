using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brigdeUPDown : MonoBehaviour
{
    public float speed = 0.05f, changeDirection = -1;
    Vector3 move;
    public Player player;
    public float khoangcach;
    public bool check;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        move = this.transform.position;
        check = false;
       
    }
    private void Update()
    {
        if (player.transform.position.x >= transform.position.x - khoangcach)
        {
            check= true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if( check==true)
        {
            move.y += speed;
            this.transform.position = move;
        }
        
        // }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ong nuoc"))
        {
            speed *= changeDirection;
        }
    }
}
