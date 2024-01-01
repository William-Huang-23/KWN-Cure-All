using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Hilang : MonoBehaviour
{
    private int timer = 0;

    void Start()
    {
        
    }
    
    void Update()
    {
        timer++;

        if(timer >= 1500)
        {
            Destroy(this.gameObject);
        }
    }
}
