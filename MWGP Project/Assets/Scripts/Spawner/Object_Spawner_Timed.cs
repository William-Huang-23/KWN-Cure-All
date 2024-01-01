using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner_Timed : MonoBehaviour
{
    private int interval = 750;
    private int interval_count = 2;

    private int timer = 0;

    [SerializeField]
    private GameObject spawned;

    void Start()
    {
        timer = interval;
    }
    
    void Update()
    {
        //Instantiate(spawned, new Vector3(Random.Range(-5, 6), 4, 0), transform.rotation);

        if (timer < interval)
        {
            timer++;
        }

        if(timer >= interval)
        {
            timer = 0;
            
            if(interval_count < 2)
            {
                interval_count++;
            }
        }
        
        spawn();
    }

    void spawn()
    {
        if(interval_count > 0)
        {
            if(Random.Range(1,750) == 1)
            {
                interval_count--;

                Instantiate(spawned, new Vector3(Random.Range(-5, 6), 4, 0), transform.rotation);
            }
        }
    }
}
