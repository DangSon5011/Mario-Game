using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Animator amin;
    public bool angry=false;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        amin = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

     void Update()
    {
        amin.SetBool("Angry", angry);
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            angry = true;
            player.Knockback();
            player.a = transform.position.y + 1;
            player.ourHealth = 0;
            //StartCoroutine(Angry());
        }
    }
    /*IEnumerator Angry()
    {
        yield return new WaitForSeconds(0.5f);
        player.ourHealth = 0;
        yield return 0;
    }*/
}
