using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkkhoangcach : MonoBehaviour
{
    public float khoangcach;
    public Player pl;
    public Rigidbody2D r2d;
    public Collider2D box;
    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        r2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((pl.transform.position.x > this.transform.position.x-khoangcach) &&(pl.transform.position.y < this.transform.position.y)
            &&(pl.transform.position.x < this.transform.position.x + khoangcach))
        {
            r2d.bodyType = RigidbodyType2D.Dynamic;
            box.isTrigger = true;
        }
    }
}
