using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    //Border
    
    void Start()
    {
        
    }

    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

        if (col.gameObject.tag == "bullet")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "bullet besar")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "enemy bullet")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
