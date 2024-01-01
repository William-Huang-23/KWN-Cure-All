using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject bullet_immune;

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

    void Update()
    {
        timer++;
        if (timer >= interval)
        {
            if(Random.Range(1,3) == 1)
            {
                shoot_biasa();
            }
            else
            {
                shoot_immune();
            }

            timer = 0;
        }
    }

    // BULLET TYPES

    void shoot_biasa()
    {
        Instantiate(bullet, new Vector3(transform.position.x + jarak_x, transform.position.y + jarak_y, 0), transform.rotation);
    }

    void shoot_immune()
    {
        Instantiate(bullet_immune, new Vector3(transform.position.x + jarak_x, transform.position.y + jarak_y, 0), transform.rotation);
    }
}
