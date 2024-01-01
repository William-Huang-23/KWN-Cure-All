using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prion_Boss : MonoBehaviour
{
    public GameObject finish;
    public GameObject spawner;

    [SerializeField]
    private int health = 10;

    private int bomb_delay = 10;

    // array bullet prefab x2

    Material material;
    bool isFadingIn = false;
    bool isDissolving = false;
    float fade = 0f;
    float fadeout = 1f;
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
            isDissolving = true;

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