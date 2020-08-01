using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brickgreen : MonoBehaviour
{

    public Player player;
    public Animator anim;
    public bool destroyed = false;
    public GameObject khonglo;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Destroyed", destroyed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("khong lo"))

        {
            if (khonglo.transform.position.y > transform.position.y )
                destroyed = true;
        }
        // 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("khong lo"))
        {

                Destroy(gameObject);
            
        }

    }

}
