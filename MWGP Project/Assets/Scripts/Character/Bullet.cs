using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    private float x_speed;

    [SerializeField]
    private float y_speed;

    [SerializeField]
    private GameObject ledakan;

    public int timer;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.velocity = new Vector2(x_speed, y_speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "boss" || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "collision enemy bullet")
        {
            Instantiate(ledakan, transform.position, transform.rotation);
            
        }
    }

    /*  private void OnCollisionEnter2D(Collision2D col)
      {
          if (col.gameObject.tag == "enemy bullet" || col.gameObject.tag == "bullet")
          {
              Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
          }
      }*/
    
}
