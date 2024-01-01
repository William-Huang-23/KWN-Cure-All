using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDissolve : MonoBehaviour
{
    Material material;

    bool isDissolving = false;
    float fade = 1f;

    private int hpchar;

    void Start()
    {
        //hpchar = Character_Take_Damage.health;
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if(hpchar <= 0)
        {
            isDissolving = true;
        }
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade);
        }

    }

}
