using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore_Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "speed" || col.gameObject.tag == "spray" || col.gameObject.tag == "big" || col.gameObject.tag == "rapid" || col.gameObject.tag == "invulnerable")
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
