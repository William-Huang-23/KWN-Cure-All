using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite_Boss_Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bullet;

    private int pattern = 0;

    private int count = 0;

    bool finish = true;

    [SerializeField]
    private int interval = 0;

    private int timer = 0;

    void Start()
    {

    }

    void Update()
    {
        timer++;

        if (finish == true)
        {
            pattern = Random.Range(1, 3);

            if (pattern == 1)
            {
                count = 0;
            }
            else if (pattern == 2)
            {
                count = 6;
            }

            finish = false;
        }

        if (timer >= interval)
        {
            shoot();

            timer = 0;
        }
    }

    void shoot()
    {
        if (pattern == 1)
        {
            Instantiate(bullet[count], new Vector3(transform.position.x, transform.position.y - 1, 0), transform.rotation);

            count++;

            if (count == 7)
            {
                finish = true;
            }
        }
        else if (pattern == 2)
        {
            Instantiate(bullet[count], new Vector3(transform.position.x, transform.position.y - 1, 0), transform.rotation);

            count--;

            if (count == -1)
            {
                finish = true;
            }
        }
    }
}
