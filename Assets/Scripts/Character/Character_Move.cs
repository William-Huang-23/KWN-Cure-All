using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    Rigidbody2D body;
    
    private float x_speed;
    
    private float y_speed;

    [SerializeField]
    private float base_speed;

    [SerializeField]
    private float x_dif;

    [SerializeField]
    private float y_dif;

    public static float xtra_speed;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        move();
    }

    private void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            y_speed = base_speed + y_dif + xtra_speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            x_speed = -x_dif -xtra_speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            y_speed = base_speed - y_dif -xtra_speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x_speed = x_dif + xtra_speed;
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            y_speed = base_speed;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            x_speed = 0f;
        }

            body.velocity = new Vector2(x_speed, y_speed);
    }
}
