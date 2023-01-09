using UnityEngine;
using UnityEngine.UI;

public class ScoreLable : MonoBehaviour
{
    [SerializeField]
    private Text scoreLabel, highscoreLabel, gameOverScoreLable;

    private static ScoreLable instance;

    public static ScoreLable getInstance()
    {
        return instance;
    }

    private void Awake()
    {
        EventManager.OnScoreChange.AddListener(ChangeScoreLabel);
        EventManager.OnGameOver.AddListener(GameOverScoreChange);
        instance = this;
    }

    private void ChangeScoreLabel()
    {
        scoreLabel.text = Score.scoreCounter.ToString();
    }

    private void GameOverScoreChange()
    {
        gameOverScoreLable.text = Score.scoreCounter.ToString();
    }

    public void ChangeHighscoreLabel()
    {
        highscoreLabel.text = Score.highscoreCounter.ToString();
    }

}
