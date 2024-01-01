using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    private float x;

    private float y;

    private float addX;

    private float addY;

    int delay = 0;
    bool marked = false;

    // Start is called before the first frame update
    void Start()
    {
        //location = Character_Take_Damage.myLocation;

        

        //  location = new Vector3(location.x, location.y, 0);

        //transform.LookAt(location);

        

        //Debug.Log(x);
        //Debug.Log(y);
    }
    

    void Update()
    {
        if(marked == false)
        {
            delay++;
        }
        
        if(delay > 1 && marked == false)
        {
            x = Character_Take_Damage.myX * 2;
            y = Character_Take_Damage.myY * 2;

            marked = true;
        }

        transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(x, y, 0), 0.025f);

        //mati

        if(transform.position == new Vector3(x, y, 0))
        {
            Destroy(this.gameObject);
        }
    }
}
