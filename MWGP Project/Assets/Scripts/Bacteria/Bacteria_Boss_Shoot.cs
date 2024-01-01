using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria_Boss_Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet_lurus;

    // Spread Shot

    [SerializeField]
    private GameObject bullet1;

    [SerializeField]
    private GameObject bullet2;

    [SerializeField]
    private GameObject bullet3;

    [SerializeField]
    private GameObject bullet4;

    [SerializeField]
    private GameObject bullet5;

    [SerializeField]
    private GameObject bullet6;

    [SerializeField]
    private GameObject bullet7;

    [SerializeField]
    private GameObject bullet8;

  //  private GameObject test;

    //

    // bounce shoot
    
    [SerializeField]
    private GameObject bouncing_bullet;

    private bool bounce_shooting = false;

    private int bounce_shoot_interval = 0 ;

    //

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
            int rando = Random.Range(1, 5);

            // shoot pattern

            if(rando == 1)
            {
                jarak_x = -7.5f;

                for(int i = 0 ; i < 6; i++)
                {
                    regular_shoot();

                    jarak_x = jarak_x + 3f;
                }

                jarak_x = 0f;
            }
            else if(rando == 2)
            {
                jarak_x = -6f;

                for (int i = 0; i < 5; i++)
                {
                    regular_shoot();

                    jarak_x = jarak_x + 3f;
                }

                jarak_x = 0f;
            }
            else if(rando == 3)
            {
                // spread shot

                spread_shoot();
            }
            else if (rando == 4)
            {
                bounce_shooting = true;
            }

            timer = 0;
        }

        // bounce shoot

        if (bounce_shooting == true)
        {
            bounce_shoot_interval++;

            if (bounce_shoot_interval == 25 || bounce_shoot_interval == 50 || bounce_shoot_interval == 75)
            {
                bounce_shoot();
            }

            if(bounce_shoot_interval >= 75)
            {
                bounce_shoot_interval = 0;
                bounce_shooting = false;
            }
        }
    }

    // SHOOT TYPES

    void regular_shoot()
    {
        shoot_lurus();
    }

    void spread_shoot()
    {
        Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        Instantiate(bullet1, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        Instantiate(bullet2, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        Instantiate(bullet3, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        Instantiate(bullet4, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        Instantiate(bullet5, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        Instantiate(bullet6, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        Instantiate(bullet7, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        Instantiate(bullet8, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);

      //  test = Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), Quaternion.Euler(0, 60, 0));

       
      /*  Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), Quaternion.Euler(0, 45, 0));
        Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), Quaternion.Euler(0, 30, 0));
        Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), Quaternion.Euler(0, 15, 0));
        Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), Quaternion.Euler(0, -15, 0));
        Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), Quaternion.Euler(0, -30, 0));
        Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), Quaternion.Euler(0, -45, 0));
        Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), Quaternion.Euler(0, -60, 0));*/
    }

    void bounce_shoot()
    {
        Instantiate(bouncing_bullet, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
    }

    // BULLET TYPES

    void shoot_lurus()
    {
        Instantiate(bullet_lurus, new Vector3(transform.position.x + jarak_x, transform.position.y + jarak_y, 0), transform.rotation);
    }
}
