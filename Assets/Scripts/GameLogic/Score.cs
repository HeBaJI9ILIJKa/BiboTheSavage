using UnityEngine;


public class Score : MonoBehaviour
{
    public static int scoreCounter, highscoreCounter;
    public static void ScoreIncrease(int value = 1)
    {
        scoreCounter += value;
       
        EventManager.SendScoreChanged();
        GravityGange();
    }

     public static void ScoreDecrease(int value = 1)
    {
        if (scoreCounter == 0) return;

        if (scoreCounter - value < 0)
        {
            value = scoreCounter;
        }

        scoreCounter -= value;
        EventManager.SendScoreChanged();
        GravityGange();
    }

    public static void GravityGange()
    {
        Physics2D.gravity = new Vector2(0f, -9.81f - (GameParameters.fallAccelerate * scoreCounter));
    }

    public static void SetDefaultScore()
    {
        scoreCounter = 0;
        highscoreCounter = 0;
        GravityGange();
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscoreCounter = PlayerPrefs.GetInt("highscore");
            ScoreLable.getInstance().ChangeHighscoreLabel();
        }
    }

    public static void SaveHighscore()
    {
        if (scoreCounter > highscoreCounter)
            highscoreCounter = scoreCounter;

        if (highscoreCounter > PlayerPrefs.GetInt("highscore"))
            PlayerPrefs.SetInt("highscore", highscoreCounter);
    }
}
