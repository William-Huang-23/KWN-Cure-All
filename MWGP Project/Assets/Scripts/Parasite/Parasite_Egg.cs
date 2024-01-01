using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite_Egg : MonoBehaviour
{
    private int health = 10;

    private int bomb_delay = 10;

    [SerializeField]
    private GameObject anak;
    
    private int hatch = 0;

    Material material;
    bool isDissolving = false;
    float fade = 1f;
    Rigidbody2D rb;
    Collider2D col;

    public Animator animator;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    
    void Update()
    {
        hatch++;

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

        if (bomb_delay < 10)
        {
            bomb_delay++;
        }

        if (bomb_delay >= 10 && Shoot_Bomb.isBomb == true)
        {
            health = health - 10;
            bomb_delay = 0;
        }

        if(hatch >= 1500)
        {
            isDissolving = true;

            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Destroy(rb);
            Destroy(col);

            Destroy(this.gameObject,0.8f);

            menetas();
        }
        
        if (health <= 0)
        {
            isDissolving = true;

            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Destroy(rb);
            Destroy(col);

            Destroy(this.gameObject, 0.8f);

            die();
        }
    }

    void menetas()
    {
        Instantiate(anak, new Vector3(transform.position.x + 1f, transform.position.y, 0), transform.rotation);

        Instantiate(anak, new Vector3(transform.position.x - 1f, transform.position.y, 0), transform.rotation);
    }

    void die()
    {
        Instantiate(anak, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

        if (col.gameObject.tag == "bullet")
        {
            health = health - 1;
            //sr.color = Color.red;
            animator.SetTrigger("isHit");
            //StartCoroutine("SwitchColor");
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "bullet besar")
        {
            health = health - 3;
            animator.SetTrigger("isHit");
            //GetComponent<Animator>().SetTrigger("isHit");
            Destroy(col.gameObject);
        }
    }
}
