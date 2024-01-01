using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore_Boss_Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bullet;

    [SerializeField]
    private int interval = 0;

    private int timer = 0;

    public Spore_Boss sporeboss;

    bool flag1 = false;
    bool flag2 = false;

    [SerializeField]
    private int pattern = 1;

    void Start()
    {
        
    }
    
    void Update()
    {
        timer++;

        if(timer >= interval)
        {
            shoot();

            timer = 0;
        }

        if(Spore_Boss.gethealth() <= 66 && flag1 == false)
        {
            pattern = 2;
            flag1 = true;
        }

        if (Spore_Boss.gethealth() <= 33 && flag2 == false)
        {
            pattern = 3;
            flag2 = true;
        }
    }

    void shoot()
    {
        int randomNo;

        if(pattern == 1)
        {
            randomNo = Random.Range(0, 7);

            Instantiate(bullet[randomNo], new Vector3(transform.position.x, transform.position.y + 3, 0), transform.rotation);
        }
        else if(pattern == 2)
        {
            randomNo = Random.Range(0, 7);

            Instantiate(bullet[randomNo], new Vector3(transform.position.x - 2f, transform.position.y + 3, 0), transform.rotation);

            randomNo = Random.Range(0, 7);

            Instantiate(bullet[randomNo], new Vector3(transform.position.x + 2f, transform.position.y + 3, 0), transform.rotation);
        }
        else if(pattern == 3)
        {
            randomNo = Random.Range(0, 7);

            Instantiate(bullet[randomNo], new Vector3(transform.position.x, transform.position.y + 3, 0), transform.rotation);

            randomNo = Random.Range(0, 7);

            Instantiate(bullet[randomNo], new Vector3(transform.position.x - 4f, transform.position.y + 3, 0), transform.rotation);

            randomNo = Random.Range(0, 7);

            Instantiate(bullet[randomNo], new Vector3(transform.position.x + 4f, transform.position.y + 3, 0), transform.rotation);

        }
    }
}
