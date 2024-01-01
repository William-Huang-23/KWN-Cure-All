using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public float speed =  1f;
    public float clampos;

    [HideInInspector] public Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }
    void FixedUpdate()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, clampos);
        transform.position = StartPosition + Vector3.up * newPosition;
    }
}
