using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_vs_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

        if (col.gameObject.tag == "bullet")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "bullet besar")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
