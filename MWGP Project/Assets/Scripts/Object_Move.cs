using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Move : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    private float x_speed;

    [SerializeField]
    private float y_speed;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();

        int x = 0;

        x = Random.Range(1, 3);

        if (x == 1)
        {
            x_speed = -1f;
        }
        else if (x == 2)
        {
            x_speed = 1f;
        }
    }
    
    void Update()
    {
        body.velocity = new Vector2(x_speed, y_speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

        if (col.gameObject.tag == "left")
        {
            x_speed = 1f;
        }

        if (col.gameObject.tag == "right")
        {
            x_speed = -1f;
        }
    }
}
