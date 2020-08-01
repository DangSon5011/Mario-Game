using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrie : MonoBehaviour
{
    public BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            box.isTrigger = true;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            box.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
         if (collision.CompareTag("Player"))
        {
            box.isTrigger = false;
        }
    }
        
    
}
