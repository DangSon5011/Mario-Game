using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoaKhongLo : MonoBehaviour
{
    public GameObject doi_tuong;
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
        if(collision.collider.CompareTag("NamGreen"))
        {
            doi_tuong.transform.localScale =   new Vector3(doi_tuong.transform.localScale.x*1.8f, doi_tuong.transform.localScale.y * 1.8f, doi_tuong.transform.localScale.z * 1.8f);
            doi_tuong.tag = "khong lo";
        }
    }
}
