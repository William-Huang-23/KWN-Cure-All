using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Take_Damage : MonoBehaviour
{

    [SerializeField]
    private GameObject parent;

    public static Vector3 myLocation;

    public static float myX;
    public static float myY;

    //[SerializeField]
    private int health = 3;
    //public static int health;

    [SerializeField]
    private int interval;

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject gameover;
    public GameObject barrier;
    public Slider slider;

    public Animator animator;
    public Animator barrieranimator;

    public GameObject head;
    public GameObject headbig;
    public GameObject headspread;
    public GameObject headrapid;
    public GameObject tail;

    Material headmaterialdef;
    Material headmaterialbig;
    Material headmaterialspread;
    Material headmaterialrapid;
    Material tailmaterial;
    Material bodymaterial;
    bool isDissolving = false;
    float fade = 1f;
    
    public float timeToColor;
    SpriteRenderer sr;
    Color defaultColor;

    bool TABon = false;
    bool CAPon = false;
    bool DISon = false;

    //public int bomb;

    void Start()
    {
        //bomb = Shoot_Bomb.jumlah;
        headmaterialdef = head.GetComponent<SpriteRenderer>().material;
        headmaterialbig = headbig.GetComponent<SpriteRenderer>().material;
        headmaterialspread = headspread.GetComponent<SpriteRenderer>().material;
        headmaterialrapid = headrapid.GetComponent<SpriteRenderer>().material;
        tailmaterial = tail.GetComponent<SpriteRenderer>().material;
        bodymaterial = GetComponent<SpriteRenderer>().material;
    }
    
    void Update()
    {
        myLocation = this.transform.position;

        myX = transform.position.x;
        myY = transform.position.y;

        if (interval > 0)
        {
            interval--;
        }

        if(interval <= 0)
        {
            barrier.SetActive(false);
            IFIndicator.animator.SetBool("IsActive",false);
        }
        if(health == 3)
        {
            hp1.SetActive(true);
            hp2.SetActive(true);
            hp3.SetActive(true);
        }
        if (health == 2)
        {
            hp1.SetActive(true);
            hp2.SetActive(true);
            hp3.SetActive(false);
        }
        if(health == 1)
        {
            hp1.SetActive(true);
            hp2.SetActive(false);
            hp3.SetActive(false);
        }

        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if(fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            bodymaterial.SetFloat("_Fade", fade);
            headmaterialdef.SetFloat("_Fade", fade);
            headmaterialbig.SetFloat("_Fade", fade);
            headmaterialrapid.SetFloat("_Fade", fade);
            headmaterialspread.SetFloat("_Fade", fade);
            tailmaterial.SetFloat("_Fade", fade);
        }

       

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "speed")
        {

            Destroy(col.gameObject);
            if (Character_Move.xtra_speed < 5)
            {
                Character_Move.xtra_speed++;
                slider.value++;
            }

            VACIndicator.animator.SetBool("IsActive", true);

            
        }

        if (col.gameObject.tag == "bomb power")
        {
            if(Shoot_Bomb.jumlah < 3)
            {
                Shoot_Bomb.jumlah++;
            }
            
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "spray")
        {
            Debug.Log("DIS ON");
            DISon = true;
            TABon = false;
            CAPon = false;
            Character_Shoot.activate_power_up(2);
            DISIndicator.animator.SetBool("IsActive", true);
            TABIndicator.animator.SetBool("IsActive", false);
            CAPIndicator.animator.SetBool("IsActive", false);
            IFIndicator.animator.SetBool("IsActive", false);

            head.SetActive(false);
            headspread.SetActive(true);
            headbig.SetActive(false);
            headrapid.SetActive(false);
            
            animator.SetBool("isSpread", true);
            animator.SetBool("isBig", false);
            animator.SetBool("isRapid", false);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "big")
        {
            Debug.Log("TAB ON");
            TABon = true;
            DISon = false;
            CAPon = false;

            Character_Shoot.activate_power_up(3);
            TABIndicator.animator.SetBool("IsActive", true);
            DISIndicator.animator.SetBool("IsActive", false);
            CAPIndicator.animator.SetBool("IsActive", false);
            IFIndicator.animator.SetBool("IsActive", false);

            head.SetActive(false);
            headspread.SetActive(false);
            headbig.SetActive(true);
            headrapid.SetActive(false);

            animator.SetBool("isSpread", false);
            animator.SetBool("isBig", true);
            animator.SetBool("isRapid", false);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "rapid")
        {
            Debug.Log("CAP ON");
            CAPon = true;
            TABon = false;
            DISon = false;

            Character_Shoot.activate_power_up(4);
            CAPIndicator.animator.SetBool("IsActive", true);
            DISIndicator.animator.SetBool("IsActive", false);
            TABIndicator.animator.SetBool("IsActive", false);
            IFIndicator.animator.SetBool("IsActive", false);
            head.SetActive(false);
            headspread.SetActive(false);
            headbig.SetActive(false);
            headrapid.SetActive(true);

            

            animator.SetBool("isSpread", false);
            animator.SetBool("isBig", false);
            animator.SetBool("isRapid", true);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "invulnerable")
        {
            if(CAPon == false && DISon == false && TABon == false)
            {
                Debug.Log("normal barrier");
                barrier.SetActive(true);
                barrieranimator.SetBool("CAPActive", false);
                barrieranimator.SetBool("DISActive", false);
                barrieranimator.SetBool("TABActive", false);
            }
            if (CAPon == true && DISon == false && TABon == false)
            {
                Debug.Log("blue barrier");
                barrier.SetActive(true);
                barrieranimator.SetBool("CAPActive",true);
                barrieranimator.SetBool("DISActive", false);
                barrieranimator.SetBool("TABActive", false);
            }
            if (CAPon == false && DISon == false && TABon == true)
            {
                Debug.Log("red barrier");
                barrier.SetActive(true);
                barrieranimator.SetBool("CAPActive", false);
                barrieranimator.SetBool("DISActive", false);
                barrieranimator.SetBool("TABActive", true);
            }
            if (CAPon == false && DISon == true && TABon == false)
            {
                Debug.Log("green barrier");
                barrier.SetActive(true);
                barrieranimator.SetBool("CAPActive", false);
                barrieranimator.SetBool("DISActive", true);
                barrieranimator.SetBool("TABActive", false);
            }
            interval = 500;
            IFIndicator.animator.SetBool("IsActive", true);
            //DISIndicator.animator.SetBool("IsActive", false);
            //TABIndicator.animator.SetBool("IsActive", false);
            //CAPIndicator.animator.SetBool("IsActive", false);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "collision enemy bullet")
        {
            Destroy(col.gameObject);

            if (interval <= 0)
            {
                health = health - 1;
                interval = 100;
                barrier.SetActive(true);

                if (health <= 0)
                {
                    Destroy(parent.gameObject, 1);
                    hp1.SetActive(false);
                    hp2.SetActive(false);
                    hp3.SetActive(false);
                    gameover.SetActive(true);
                    isDissolving = true;
                    Time.timeScale = 0.5f;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Bacteria_Bullet bacteria_bullet = col.GetComponent<Bacteria_Bullet>();

        if (col.gameObject.tag == "enemy bullet")
        {
            Destroy(col.gameObject);

            if (interval <= 0)
            {
                health = health - 1;
                interval = 100;
                barrier.SetActive(true);

                if (health <= 0)
                {
                    Destroy(parent.gameObject,1);
                    hp1.SetActive(false);
                    hp2.SetActive(false);
                    hp3.SetActive(false);
                    gameover.SetActive(true);
                    isDissolving = true;
                    Time.timeScale = 0.5f;
                }
            }
        }

        if (col.gameObject.tag == "enemy" && interval <= 0)
        {
            health = health - 1;
            interval = 100;
            barrier.SetActive(true);

            if (health <= 0)
            {
                //Destroy(parent.gameObject);
                hp1.SetActive(false);
                hp2.SetActive(false);
                hp3.SetActive(false);
                gameover.SetActive(true);
                isDissolving = true;
                Time.timeScale = 0.5f;
                Destroy(parent.gameObject,1);
            }
        }

        if (col.gameObject.tag == "boss" && interval <= 0)
        {
            health = health - 1;
            interval = 100;
            barrier.SetActive(true);

            if (health <= 0)
            {
                //Destroy(parent.gameObject);
                hp1.SetActive(false);
                hp2.SetActive(false);
                hp3.SetActive(false);
                gameover.SetActive(true);
                isDissolving = true;
                Time.timeScale = 0;
                Destroy(parent.gameObject,1);
            }
        }

        if (col.gameObject.tag == "bomb")
        {
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        Bacteria_Bullet bacteria_bullet = col.GetComponent<Bacteria_Bullet>();

        if (col.gameObject.tag == "enemy bullet")
        {
            Destroy(col.gameObject);

            if (interval <= 0)
            {
                health = health - 1;
                interval = 100;
                barrier.SetActive(true);

                if (health <= 0)
                {
                    Destroy(parent.gameObject, 1);
                    hp1.SetActive(false);
                    hp2.SetActive(false);
                    hp3.SetActive(false);
                    gameover.SetActive(true);
                    isDissolving = true;
                    Time.timeScale = 0.5f;
                }
            }
        }

        if (col.gameObject.tag == "enemy" && interval <= 0)
        {
            health = health - 1;
            interval = 100;
            barrier.SetActive(true);

            if (health <= 0)
            {
                //Destroy(parent.gameObject);
                hp1.SetActive(false);
                hp2.SetActive(false);
                hp3.SetActive(false);
                gameover.SetActive(true);
                isDissolving = true;
                Time.timeScale = 0.5f;
                Destroy(parent.gameObject, 1);
            }
        }

        if (col.gameObject.tag == "boss" && interval <= 0)
        {
            health = health - 1;
            interval = 100;
            barrier.SetActive(true);

            if (health <= 0)
            {
                //Destroy(parent.gameObject);
                hp1.SetActive(false);
                hp2.SetActive(false);
                hp3.SetActive(false);
                gameover.SetActive(true);
                isDissolving = true;
                Time.timeScale = 0;
                Destroy(parent.gameObject, 1);
            }
        }

     /*   if (col.gameObject.tag == "bomb")
        {
            Shoot_Bomb.jumlah += 1;
            Destroy(col.gameObject);
        }*/
    }
}
