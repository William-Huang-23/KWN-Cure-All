using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    // public int scoreLarge;
    //  public int scoreMedium;
    //  public int scoreSmall;
    //  public int totalScore;

    public static int score;

    public Text scoretotal;

    void Start()
    {
        //scoretotal.text = scoretotal.text.GameObject.FindGameObjectWithTag("Counter");
     //   scoreLarge = Bacteria_Large.score;
     //   scoreMedium = Bacteria_Medium.score;
     //   scoreSmall = Bacteria_Small.score;

    //    totalScore = (scoreLarge + scoreMedium + scoreSmall);
        //totalScore = (scoreSmall + scoreMedium + scoreLarge);
    }

    void Update()
    {
        scoretotal = GameObject.Find("Counter").GetComponent<Text>();
        //   scoretotal.text = "" + totalScore.ToString();
        scoretotal.text = "" + score.ToString();
        //Debug.Log("total skor :" + totalScore);
    }
}