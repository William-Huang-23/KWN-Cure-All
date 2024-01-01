using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria_Bullet : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    private float Xspeed;

    [SerializeField]
    private float Yspeed;

 //   public int testervariable = 0;

    //Vector3 offset = new Vector3(0f,-0.05f,0f);

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.velocity = new Vector2(Xspeed, Yspeed);
        //transform.position += transform.TransformDirection(offset);
    }

   /* private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "speed")
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (col.gameObject.tag == "enemy bullet" || col.gameObject.tag == "bullet")
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }*/
}
