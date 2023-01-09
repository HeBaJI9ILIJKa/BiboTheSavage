using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    [SerializeField]
    private GameObject playScreen, pauseScreen, gameOverScreen;

    private static ScreenControl instance;

    public static ScreenControl getInstance()
    {
        return instance;
    }

    public void Awake()
    {
        instance = this;
    }

    public void PauseScreenSetActive(bool value)
    {
        pauseScreen.SetActive(value);
        playScreen.SetActive(!value);
    }

    public void GameOverScreenSetActive()
    {
        playScreen.SetActive(false);
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
