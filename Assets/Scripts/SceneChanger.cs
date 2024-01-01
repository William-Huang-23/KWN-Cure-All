using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        ResetValue();
    }

    public void PlayTest()
    {
        SceneManager.LoadScene("Test Scene DK");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("High Score");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void PowerUpDesc()
    {
        SceneManager.LoadScene("Power Up");
    }

    public void EnemyDesc()
    {
        SceneManager.LoadScene("Enemy");
    }

    public void StageSelect()
    {
        SceneManager.LoadScene("Stage Select");
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Test Scene Prion");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Test Scene Spore");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("Test Scene Parasite");
    }

    public void Stage4()
    {
        SceneManager.LoadScene("Test Scene Bacteria");
    }

    public void Stage5()
    {
        SceneManager.LoadScene("Test Scene Virus");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetValue();
    }

    public void FinishStage()
    {
        
    }

    void ResetValue()
    {
        ScoreCounter.score = 0;
        Character_Shoot.activate_power_up(1);
        Character_Move.xtra_speed = 0;
        Shoot_Bomb.jumlah = 3;
        Time.timeScale = 1;
    }

}
