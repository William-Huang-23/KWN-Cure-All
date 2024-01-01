using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Border border = collision.GetComponent<Border>();

        if (collision.gameObject.tag == "top" || collision.gameObject.tag == "bot" || collision.gameObject.tag == "left" || collision.gameObject.tag == "right")
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
