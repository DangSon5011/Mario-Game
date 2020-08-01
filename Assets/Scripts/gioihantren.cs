using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gioihantren : MonoBehaviour
{
    public float limit_tren;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(this.transform.position.y>limit_tren)
        {
            Destroy(gameObject);
        }
    }
}
