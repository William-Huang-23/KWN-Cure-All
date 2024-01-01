using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prion_Boss_Move : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    float speed = 0.02f;

    [SerializeField]
    int index = 0;

    int x;

    void Start()
    {
        
    }
    
    void Update()
    {
        move();
    }

    void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[index].transform.position, speed);

        change_index();
    }

    void change_index()
    {
        if(transform.position.x == -7 && transform.position.y == 3)
        {
            index = 1;
        }
        else if (transform.position.x == -7 && transform.position.y == -4)
        {
            index = 2;
        }
        else if (transform.position.x == 7 && transform.position.y == -4)
        {
            index = 3;
        }
        else if (transform.position.x == 7 && transform.position.y == 3)
        {
            index = 0;
        }
    }

    void random_index()
    {
        if (transform.position.x == -7 && transform.position.y == 3)
        {
            random();
        }
        else if (transform.position.x == -7 && transform.position.y == -4)
        {
            random();
        }
        else if (transform.position.x == 7 && transform.position.y == -4)
        {
            random();
        }
        else if (transform.position.x == 7 && transform.position.y == 3)
        {
            random();
        }
    }

    void random()
    {
        x = Random.Range(1, 3);

        if (x == 1)
        {
            index--;
        }
        else
        {
            index++;
        }

        if (index == 4)
        {
            index = 0;
        }

        if (index == -1)
        {
            index = 4;
        }
    }
}
