using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rua_killed : MonoBehaviour
{

    public Player player;
    public GameObject Rua,mai_rua;
    public bool checkkill=false;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkkill==true)
        {
            Destroy(Rua.gameObject);
            Instantiate(mai_rua, this.transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player.r2.AddForce(new Vector2(0, 310f));
            checkkill = true;
            
           
            
        }
    }
   

}
