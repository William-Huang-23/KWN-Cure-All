using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite_Bullet : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    private float Xspeed;

    [SerializeField]
    private float Yspeed;

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.velocity = new Vector2(Xspeed, Yspeed);
    }
}
