using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public static GameObject gameover;
    public static int score1;
    public static int score2;
    public Text scoretext;
    public Slider slider;

    void Start()
    {
        //score1 = Take_Damage.score;
        //score2 = Bacteria_Split.score;
    }

    void Update()
    {
        //scoretext.text = "" + (score1.ToString() + score2.ToString());

    }
}
