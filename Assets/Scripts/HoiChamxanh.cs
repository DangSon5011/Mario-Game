using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoiChamxanh : MonoBehaviour
{
    public GameObject ghost2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            
            {
                
                Instantiate(ghost2, ghost2.transform.position + new Vector3(0, Random.Range(-1f,1f),0), ghost2.transform.rotation);
                Instantiate(ghost2, ghost2.transform.position + new Vector3(0, Random.Range(-1f, 1f), 0), ghost2.transform.rotation);
                Instantiate(ghost2, ghost2.transform.position + new Vector3(0, Random.Range(-1f, 1f), 0), ghost2.transform.rotation);
                Instantiate(ghost2, ghost2.transform.position + new Vector3(0, Random.Range(-1f, 1f), 0), ghost2.transform.rotation);
                Instantiate(ghost2, ghost2.transform.position + new Vector3(0, Random.Range(-1f, 1f), 0), ghost2.transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}
