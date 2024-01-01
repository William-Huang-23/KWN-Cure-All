using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border_Bawah : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "collision enemy bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
