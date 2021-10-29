using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{
    
    public Player player;
    public Animator anim;
    public bool destroyed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim= gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Destroyed", destroyed);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   if (collision.CompareTag("Player"))

        {
            if (player.transform.position.y < transform.position.y - 0.5)
                destroyed = true;
        }
      // 
    }
  private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (player.transform.position.y < transform.position.y - 0.5)
            {

                Destroy(gameObject);
            }
        }

    }
   
}
