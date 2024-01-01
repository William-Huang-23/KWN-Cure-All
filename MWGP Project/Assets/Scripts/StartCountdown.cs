using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public GameObject spawner;

    void Start()
    {
        //Time.timeScale = 0;
        StartCoroutine(CountdownStart());
    }

    void Update()
    {
        
    }

    IEnumerator CountdownStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.text = "START";
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
        spawner.SetActive(true);
        //Time.timeScale = 1;
    }
}
