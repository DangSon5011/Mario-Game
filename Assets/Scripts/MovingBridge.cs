using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBridge : MonoBehaviour
{
    public float speed = 0.05f, changeDirection = -1;
    Vector3 move;
    public PauseMenu PauseP;

    // Start is called before the first frame update
    void Start()
    {
         move = this.transform.position;

        PauseP = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
            move.x += speed;
            this.transform.position = move;
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
