using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite_Boss_Move : MonoBehaviour
{
    Rigidbody2D body;

    private float Xspeed;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();

        int x = 0;

        x = Random.Range(1, 3);

        if (x == 1)
        {
            Xspeed = -3f;
        }
        else if (x == 2)
        {
            Xspeed = 3f;
        }
    }

    void Update()
    {
        body.velocity = new Vector2(Xspeed, 0);
    }

   

    private void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

        if (col.gameObject.tag == "left")
        {
            Xspeed = 3f;
        }

        if (col.gameObject.tag == "right")
        {
            Xspeed = -3f;
        }
    }
}
