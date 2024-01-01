using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing_Bacteria_Bullet : MonoBehaviour
{
    Rigidbody2D body;
    
    private float Xspeed;

    [SerializeField]
    private float Yspeed;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();

        int x = 0;

        x = Random.Range(1, 3);

        if(x == 1)
        {
            Xspeed = -4;
        }
        else if(x == 2)
        {
            Xspeed = 4;
        }
    }

    void Update()
    {
        body.velocity = new Vector2(Xspeed, Yspeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "left")
        {
            Xspeed = 4f;
        }

        if (collision.gameObject.tag == "right")
        {
            Xspeed = -4f;
        }

        if(collision.gameObject.tag == "collision enemy bullet")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
