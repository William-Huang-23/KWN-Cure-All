using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria_Boss : MonoBehaviour
{
    public GameObject finish;
    public GameObject spawner;

    private int health = 100;

    private static int health_show = 100;

    private int bomb_delay = 10;

    float push;

    public GameObject scorecounter;
    public ScoreCounter script;
    public static int score;

    Material material;
    bool isFadingIn = false;
    bool isDissolving = false;
    float fade = 0f;
    float fadeout = 1f;

    Rigidbody2D rb;
    Collider2D col;

    SpriteRenderer sprite;

    public Animator animator;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<SpriteRenderer>().material;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        
        health_show = health;

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
            fadeout -= Time.deltaTime;
            if (fadeout <= 0f)
            {
                fadeout = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fadeout);
        }

        if (health <= 0)
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Destroy(rb);
            Destroy(col);
            spawner.SetActive(false);
            finish.SetActive(true);
            isDissolving = true;
            Time.timeScale = 0.5f;
            Destroy(this.gameObject, 0.8f);
            ScoreCounter.score += 10;
        }
    }

    /* void OnCollisionEnter2D(Collision2D col)
     {
         if (col.gameObject.tag == "bullet")
         {
             health = health - 1;
             Destroy(col.gameObject);
         }

         if (col.gameObject.tag == "bullet besar")
         {
             health = health - 3;
             Destroy(col.gameObject);
         }
     }*/

    private void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

        if (col.gameObject.tag == "bullet")
        {
            health = health - 1;
            //animator.SetTrigger("isHit");
            //sprite.color = new Color(1, 0, 0, 1);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "bullet besar")
        {
            health = health - 3;
            //animator.SetTrigger("isHit");
            Destroy(col.gameObject);
        }
    }

    public static int gethealth()
    {
        return health_show;
    }

    public void BossFadeIn()
    {
        isFadingIn = true;
        fade += Time.deltaTime;
        if (fade >= 1f)
        {
            fade = 1f;
            isFadingIn = false;
        }
        material.SetFloat("_Fade", fade);
    }
}
