using System.Collections;
using UnityEngine;


public class Game : MonoBehaviour
{
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        GameStart();  
    }

    private void GameStart()
    {
        EventManager.OnGameOver.AddListener(GameOver);
        GameParameters.SetDefaultParameters();
        Score.SetDefaultScore();
        GetComponent<BorderPlacer>().PlaceBorders();
        Spawner.GetInstance().StartSpawning();
    }

    public void GameOver()
    {
        Spawner.GetInstance().StopSpawning();
        GameParameters.gameRunnig = false;
        Time.timeScale = 0f;

        ScreenControl.getInstance().GameOverScreenSetActive();

        Score.SaveHighscore();
    }


}
