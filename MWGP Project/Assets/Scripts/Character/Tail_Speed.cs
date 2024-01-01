using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail_Speed : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        
    }

    void Update()
    {
        if(Character_Move.xtra_speed == 1)
        {
            animator.SetInteger("speed",1);
        }
        if (Character_Move.xtra_speed == 2)
        {
            animator.SetInteger("speed", 2);
        }
        if (Character_Move.xtra_speed == 3)
        {
            animator.SetInteger("speed", 3);
        }
        if (Character_Move.xtra_speed == 4)
        {
            animator.SetInteger("speed", 4);
        }
    }
}
