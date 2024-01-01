using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Indicator : MonoBehaviour
{
    public Game_Manager game_manager;

    [SerializeField]
    private int level;

    void Start()
    {
        game_manager.level = level;
        //Debug.Log(game_manager.level);
    }
    
    void Update()
    {
        
    }
}
