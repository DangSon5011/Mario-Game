using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidenBrick2 : MonoBehaviour
{
    public GameObject Hiden;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
        //Instantiate(Hiden, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (player.transform.position.y < transform.position.y)
        {
            Instantiate(Hiden, transform.position, transform.rotation);
        }
        
    }

}
