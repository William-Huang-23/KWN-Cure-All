using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_Boss : MonoBehaviour
{
    public GameObject finish;
    public GameObject spawner;

    [SerializeField]
    private int health = 50;

    private int bomb_delay = 10;

    [SerializeField]
    private GameObject[] bullet;

    [SerializeField]
    private GameObject[] bullet_immune;

    [SerializeField]
    private int interval;

    [SerializeField]
    private float[] jarak_x;

    [SerializeField]
    private float[] jarak_y;

    private int timer;

    public Animator animator;

    Material material;
    bool isFadingIn = false;
    bool isDissolving = false;
    float fade = 0f;
    float fadeout = 1f;

    Rigidbody2D rb;
    Collider2D col;

    // array bullet prefab x2

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

        timer++;
        if (timer >= interval)
        {
            for(int i = 0; i < 8; i++)
            {
                if (Random.Range(1, 3) == 1)
                {
                    shoot_biasa(i);
                }
                else
                {
                    shoot_immune(i);
                }
            }
            timer = 0;
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

        if (health <= 20)
        {
            animator.SetBool("isHurt", true);
        }
        if (health <= 10)
        {
            animator.SetBool("isDanger", true);
        }

        if (health <= 0)
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Destroy(rb);
            Destroy(col);

            ScoreCounter.score += 10;

            finish.SetActive(true);
            isDissolving = true;
            Time.timeScale = 0.5f;
            Destroy(this.gameObject, 0.8f);
        }
    }

    void shoot_biasa(int order)
    {
        Instantiate(bullet[order], new Vector3(transform.position.x + jarak_x[order], transform.position.y + jarak_y[order], 0), transform.rotation);
    }

    void shoot_immune(int order)
    {
        Instantiate(bullet_immune[order], new Vector3(transform.position.x + jarak_x[order], transform.position.y + jarak_y[order], 0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.GetComponent<Bullet>();

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
