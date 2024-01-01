using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite_Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet_lurus;

    [SerializeField]
    private int interval;

    [SerializeField]
    private float jarak_x;

    [SerializeField]
    private float jarak_y;

    private int timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer >= interval)
        {
            regular_shoot();
            timer = 0;
        }
    }

    void regular_shoot()
    {
        Instantiate(bullet_lurus, new Vector3(transform.position.x + jarak_x, transform.position.y + jarak_y, 0), transform.rotation);
    }
}
