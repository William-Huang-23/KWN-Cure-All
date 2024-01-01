using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMeledak : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(EffectTimer());
        Destroy(this.gameObject,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    /*IEnumerator EffectTimer()
    {
        Debug.Log("nyala");
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        Debug.Log("efek selesai");
    }*/
}
