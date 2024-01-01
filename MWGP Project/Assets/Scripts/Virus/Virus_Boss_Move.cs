using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_Boss_Move : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    private float x_speed;

    [SerializeField]
    private float y_speed;

    private int awal;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();

        awal = Random.Range(1, 4);

        if (awal <= 2)
        {
            x_speed = -2;
        }
        else if (awal >= 3)
        {
            x_speed = 2;
        }

        y_speed = -2;
    }

    void Update()
    {
        body.velocity = new Vector2(x_speed, y_speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Border border = col.GetComponent<Border>();

        if (col.gameObject.tag == "top")
        {
            y_speed = -2f;
        }

        if (col.gameObject.tag == "bot")
        {
            y_speed = 2f;
        }

        if (col.gameObject.tag == "left")
        {
            x_speed = 2f;
        }

        if (col.gameObject.tag == "right")
        {
            x_speed = -2f;
        }
    }
}
