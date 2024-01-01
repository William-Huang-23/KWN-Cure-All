using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField]
    private int health = 20;

    private int bomb_delay = 10;

    // List Power Up yang Bisa Drop

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

    public Animator animator;

    Material material;
    bool isDissolving = false;
    float fade = 1f;
    Rigidbody2D rb;
    Collider2D col;

    void Start()
    {
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
        if(health <= 13)
        {
            animator.SetBool("isHurt", true);
        }
        if(health <= 6)
        {
            animator.SetBool("isDanger", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

        if (col.gameObject.tag == "bullet")
        {
            health = health - 1;
            animator.SetTrigger("isHit");
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "bullet besar")
        {
            health = health - 3;
            animator.SetTrigger("isHit");
            Destroy(col.gameObject);
        }
    }
}
