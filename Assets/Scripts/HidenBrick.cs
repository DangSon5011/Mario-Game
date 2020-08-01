using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidenBrick : MonoBehaviour
{
    public Player player;
    public GameObject BrickHiden;
    public bool check;
    public float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        
    }
    private void Update()
    {
        if (check==true)
        {
            if (player.r2.velocity.y > 0)

            {
                Destroy(gameObject);
                Instantiate(BrickHiden, transform.position+ new Vector3(x,y,z), transform.rotation);
            }
            else
            {
                check = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //if (player.transform.position.y< transform.position.y &&  player.r2.velocity.y > 0)

            {
                check = true;

            }
           // else
            {
            //    check = false;
            }
        }
        
    }
    }
   
    // Update is called once per frame




