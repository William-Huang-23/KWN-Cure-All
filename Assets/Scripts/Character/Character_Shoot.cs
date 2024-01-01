using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet_lurus;

    [SerializeField]
    private GameObject bullet_kiri;

    [SerializeField]
    private GameObject bullet_kanan;

    [SerializeField]
    private GameObject bullet_besar;

    [SerializeField]
    private GameObject bullet_lurus_spread;

    [SerializeField]
    private GameObject bullet_rapid;

    [SerializeField]
    private int interval;

    [SerializeField]
    private float jarak_x;

    [SerializeField]
    private float jarak_y;

    private int timer;
    
    public static int shoot_type = 1;   // 1 normal     2 spray
    private static int duration;

    public AudioSource shootsound;

    void Start()
    {
        
    }
    
    void Update()
    {
        timer++;
        if (timer >= interval)
        {
            switch(shoot_type)
            {
                case 1: interval = 50; regular_shoot(); break;
                case 2: interval = 50; spray_shoot(); break;
                case 3: interval = 50; big_shoot(); break;
                case 4: interval = 25; regular_shoot_rapid(); break;
            }
            timer = 0;
        }
    }

    public static void activate_power_up(int x)
    {
        shoot_type = x;
    }

    // SHOOT TYPES

    void regular_shoot()
    {
        shoot_lurus();
    }
    void regular_shoot_rapid()
    {
        shoot_lurus_rapid();
    }
    void spray_shoot()
    {
        shoot_lurus_spread();
        shoot_kiri();
        shoot_kanan();
    }

    void big_shoot()
    {
        big_bullet();
    }

    // BULLET TYPES

    void shoot_lurus()
    {
        Instantiate(bullet_lurus, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        shootsound.Play();
    }
    void shoot_lurus_spread()
    {
        Instantiate(bullet_lurus_spread, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        shootsound.Play();
    }
    void shoot_lurus_rapid()
    {
        Instantiate(bullet_rapid, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        shootsound.Play();
    }
    void shoot_kiri()
    {
        Instantiate(bullet_kiri, new Vector3(transform.position.x - jarak_x, transform.position.y + jarak_y, 0), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45f)));
        shootsound.Play();
    }

    void shoot_kanan()
    {
        Instantiate(bullet_kanan, new Vector3(transform.position.x + jarak_x, transform.position.y + jarak_y, 0), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 45f)));
        shootsound.Play();
    }

    void big_bullet()
    {
        Instantiate(bullet_besar, new Vector3(transform.position.x, transform.position.y + jarak_y, 0), transform.rotation);
        shootsound.Play();
    }
    void rapid_shoot()
    {
        interval = 50;
    }
}
