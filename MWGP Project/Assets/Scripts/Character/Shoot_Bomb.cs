using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot_Bomb : MonoBehaviour
{
    public static int jumlah = 3;

    [SerializeField]
    private GameObject bombnya;

    private int gcd = 15;

    public Text counter;

    public static bool isBomb = false;

    public AudioSource bombsound;

    public Material material;
    public GameObject bombeffect;
    bool isBlooming = false;
    float scale = 0f;

    void Start()
    {

    }
    
    void Update()
    {
        if(gcd > 0)
        {
            gcd--;
        }
        
        if(gcd <= 5)
        {
            isBomb = false;
        }

        bomb();
        

        counter.text = "" + jumlah.ToString();
        if (isBlooming)
        {
            scale += Time.deltaTime;
            if (scale >= 1f)
            {
                scale = 1f;
                isBlooming = false;
                bombeffect.SetActive(false);
                
            }
            material.SetFloat("_Scale", scale);
        }

    }

    void bomb()
    {
        if (Input.GetKey(KeyCode.Space) && jumlah > 0 && gcd <= 0)
        {
            //Instantiate(bombnya, new Vector3(0, 0, 0), transform.rotation);

            jumlah--;

            gcd = 15;

            isBomb = true;

            bombsound.Play();

            isBlooming = true;
            
            bombeffect.SetActive(true);

            scale = 0f;
        }
    }
}
