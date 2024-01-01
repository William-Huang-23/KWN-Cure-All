using System.Collections;
using UnityEngine;

public class StartDelayScript : MonoBehaviour
{
    public GameObject countdown;

    public GameObject count1;
    public GameObject count2;
    public GameObject count3;


    void Start()
    {
        StartCoroutine("StartDelay");
    }


    void Update()
    {

    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            if (pauseTime == 1)
            {
                count1.gameObject.SetActive(true);
                count2.gameObject.SetActive(false);
                count3.gameObject.SetActive(false);
            }
            if (pauseTime == 2)
            {
                count1.gameObject.SetActive(false);
                count2.gameObject.SetActive(true);
                count3.gameObject.SetActive(false);
            }
            if(pauseTime == 3)
            {
                count1.gameObject.SetActive(false);
                count2.gameObject.SetActive(false);
                count3.gameObject.SetActive(true);
            }
            yield return 0;
        }

        countdown.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
