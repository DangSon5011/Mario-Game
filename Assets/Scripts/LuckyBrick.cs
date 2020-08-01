using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyBrick : MonoBehaviour
{
    public Player player;
    public Animator anim;
    public GameObject brick,qua;
    public bool destroyed = false;
    public int soluong=1,i=0;
    Vector3 mov;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = gameObject.GetComponent<Animator>();
        mov = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Destroyed", destroyed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (soluong == 1)

            {
                if (player.transform.position.y < transform.position.y - 0.5)
                {
                    destroyed = true;
                    Destroy(gameObject);
                    Instantiate(brick, transform.position, transform.rotation);
                    Instantiate(qua, transform.position + new Vector3(0, 2f, 0), transform.rotation);

                }
            }
            else
            {
                for (i = 0; i < soluong; i++)


                {
                    if (player.transform.position.y < transform.position.y - 0.5)
                    {
                        destroyed = true;
                        Destroy(gameObject);
                        Instantiate(brick, transform.position, transform.rotation);
                        Instantiate(qua, transform.position + new Vector3(0, 2f + i, 0), transform.rotation);
                    }
                }
            }
        }
        // 
    }
    

}
