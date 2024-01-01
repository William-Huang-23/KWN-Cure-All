using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore_Split : MonoBehaviour
{
    [SerializeField]
    private int health;

    private int bomb_delay = 10;

    //  [SerializeField]
    //   private GameObject[] anak_spora;

    //   [SerializeField]
    //   private GameObject[] anak_spora2;

    [SerializeField]
    private GameObject[] death_spore;

    [SerializeField]
    private GameObject explosion;

 //   [SerializeField]
 //   private float[] jarak_x;

 //   [SerializeField]
 //   private float[] jarak_y;

 //   [SerializeField]
  //  private float[] jarak_x2;

  //  [SerializeField]
 //   private float[] jarak_y2;

    [SerializeField]
    private GameObject vaccine;

    [SerializeField]
    private GameObject invulnerability;

    [SerializeField]
    private GameObject capsule;

    [SerializeField]
    private GameObject tablet;

    [SerializeField]
    private GameObject disinfectant;

    [SerializeField]
    private GameObject bomb;

    Material material;
    bool isDissolving = false;
    float fade = 1f;
    Rigidbody2D rb;
    Collider2D col;

    public SpriteRenderer sprite;
    Color defaultcolor;

    bool isHit = false;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        defaultcolor = sprite.color;
        material = GetComponent<SpriteRenderer>().material;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (bomb_delay < 10)
        {
            bomb_delay++;
        }

        if (bomb_delay >= 10 && Shoot_Bomb.isBomb == true)
        {
            health = health - 10;
            bomb_delay = 0;
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
        if (health <= 0)
        {
            isDissolving = true;

            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Destroy(rb);
            Destroy(col);
            ScoreCounter.score += 1;
            /* int i = Random.Range(0, 2);
             for( ; i < 8; i+=2)
             {
                 spawn(i);
             }*/

            for (int i = 0; i < 5 ; i++)
               {
                   death(i);
               }

            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

            if (Random.Range(1, 6) == 1)
            {
                int rando = Random.Range(1, 7);

                switch (rando)
                {
                    case 1: Instantiate(vaccine, transform.position, transform.rotation); break;
                    case 2: Instantiate(invulnerability, transform.position, transform.rotation); break;
                    case 3: Instantiate(capsule, transform.position, transform.rotation); break;
                    case 4: Instantiate(tablet, transform.position, transform.rotation); break;
                    case 5: Instantiate(disinfectant, transform.position, transform.rotation); break;
                    case 6: Instantiate(bomb, transform.position, transform.rotation); break;
                }
            }

            Destroy(this.gameObject,0.8f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

        if (!isHit)
        {
            if (col.gameObject.tag == "bullet")
            {
                health = health - 1;
                animator.SetTrigger("isHit");
                //sprite.color = Color.red;
                //isHit = true;
                //StartCoroutine("SwitchColor");
                Destroy(col.gameObject);
            }
        }

        if (col.gameObject.tag == "bullet besar")
        {
            health = health - 3;
            animator.SetTrigger("isHit");
            Destroy(col.gameObject);
        }

     /*   if (col.gameObject.tag == "bomb" && bomb_delay >= 10 && Shoot_Bomb.isBomb == true)
        {
            health = health - 5;
            bomb_delay = 0;
        }*/

           if(col.gameObject.tag == "bot")
           {
               for (int i = 0; i < 5; i++)
               {    
                death(i);
               }
           }
    }

    /*   void spawn(int order)
       {
           Instantiate(anak_spora[order], new Vector3(transform.position.x + jarak_x[order], transform.position.y, 0), transform.rotation);
       }

       void spawn2(int order)
       {
           Instantiate(anak_spora2[order], new Vector3(transform.position.x + jarak_x2[order], transform.position.y, 0), transform.rotation);
       }*/

    void death(int order)
    {
        Instantiate(death_spore[order], new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}

