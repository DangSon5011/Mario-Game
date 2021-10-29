using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public MovingBridge mov;
    public Vector3 movp;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
        mov = GameObject.FindGameObjectWithTag("MovingBridge").GetComponent<MovingBridge>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        player.Grounded = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        player.Grounded = true;
        if (collision.isTrigger==false && collision.CompareTag("MovingBridge"))
        {
            
            movp = player.transform.position;
            movp.x += mov.speed*0.5f;
            player.transform.position = movp;
            
        }
       
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.Grounded = false;
    }
}
