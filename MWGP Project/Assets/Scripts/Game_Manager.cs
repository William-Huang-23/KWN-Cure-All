using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    // public int targetFrameRate = 60;

    public GameObject pausemenu;
    bool pause = false;
    public GameObject spawner;

    [SerializeField]
    private GameObject boss;

    private float timer = 0.0f;

    public Bacteria_Boss bacteriaBoss;
    Bacteria_Boss BossBacteria;

    public Parasite_Boss parasiteBoss;
    Parasite_Boss BossParasite;

    public Prion_Boss prionBoss;
    Prion_Boss BossPrion;

    public Spore_Boss sporeBoss;
    Spore_Boss BossSpore;

    public Virus_Boss virusBoss;
    Virus_Boss BossVirus;

    public int level = 0;

    /*Character_Take_Damage chara;

    public GameObject finish;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;*/

    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = targetFrameRate;
        //Time.timeScale = 0;
        //timer = Time.time;
        BossBacteria = bacteriaBoss.GetComponent<Bacteria_Boss>();
        BossParasite = parasiteBoss.GetComponent<Parasite_Boss>();
        BossPrion = prionBoss.GetComponent<Prion_Boss>();
        BossSpore = sporeBoss.GetComponent<Spore_Boss>();
        BossVirus = virusBoss.GetComponent<Virus_Boss>();

    }
    
    void Update()
    {
        timer += Time.deltaTime;
        /*if(timer < 10)
        {
            timer++;
        }*/
        
        if(timer >= 180)
        {   
            boss.SetActive(true);

            switch(level)
            {
                case 1: BossPrion.BossFadeIn(); break;
                case 2: BossSpore.BossFadeIn(); break;
                case 3: BossParasite.BossFadeIn(); break;
                case 4: BossBacteria.BossFadeIn(); break;
                case 5: BossVirus.BossFadeIn(); break;
            } 
        }

        /*if (finish.activeSelf == true)
        {
            Debug.Log("finish nyala");
            chara.barrier.SetActive(true);
            spawner1.SetActive(false);
            spawner2.SetActive(false);
            spawner3.SetActive(false);
        }*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                pausemenu.SetActive(false);
                spawner.SetActive(true);
                Time.timeScale = 1;
            }
            
            else
            {
                pausemenu.SetActive(true);
                spawner.SetActive(false);
                Time.timeScale = 0;
            }

            pause = !pause;
        }

    }
}
