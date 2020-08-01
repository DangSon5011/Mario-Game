using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersBox : MonoBehaviour
{
    public Player player;
    public GameObject hoaanthit1;
    public bool check=false;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(check==true)
        {
            Destroy(gameObject);
            Instantiate(hoaanthit1, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            check = true;
            
        }
    }
}
