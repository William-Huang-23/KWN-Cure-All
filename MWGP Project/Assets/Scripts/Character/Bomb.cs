using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int delay = 0;

    void Start()
    {
        
    }
    
    void Update()
    {
        delay++;

        if(delay >= 5)
        {
            Destroy(this.gameObject);
        }
    }

   /* private void LateUpdate()
    {
        Destroy(this.gameObject);
    }*/
}
