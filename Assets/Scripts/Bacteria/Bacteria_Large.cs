using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria_Large : MonoBehaviour
{
    private int health = 6;

    private int bomb_delay = 10;

    [SerializeField]
    private GameObject anak;

    public GameObject scorecounter;
    public ScoreCounter script;
    // public static int score;

    public float timeToColor = 0.25f;

    bool isHit = false;
    public SpriteRenderer sprite;
    Color defaultcolor;

    Material material;
    bool isDissolving = false;
    float fade = 1f;

    Rigidbody2D rb;
    Collider2D col;

    public Animator animator;
    //RuntimeAnimatorController ac;


    void Start()
    {
        //ac = GetComponent<RuntimeAnimatorController>();
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
            Destroy(this.gameObject,0.8f);
            spawn();
        }
        //GetComponent<Animator>().SetBool("isHit", false);

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
            //GetComponent<Animator>().SetTrigger("isHit");
            Destroy(col.gameObject);
        }
    }

    void spawn()
    {
        Instantiate(anak, new Vector3(transform.position.x + 1f, transform.position.y, 0), transform.rotation);

        Instantiate(anak, new Vector3(transform.position.x - 1f, transform.position.y, 0), transform.rotation);
    }

    /*IEnumerator SwitchColor()
    {
        animator.enabled = false;
        sprite.color = new Color(1, 0, 0, 1);
        animator.enabled = true;
        yield return new WaitForSeconds(timeToColor);
        //sprite.color = defaultcolor;
        //isHit = false;
        Debug.Log("berubah warna");
    }*/

}


