using UnityEngine;

public static class GameParameters
{
    public static bool gameRunnig;
    public static float spawnInterval = 1.2f, fallAccelerate = 0.1f, playerSpeed = 3f;
    public static Vector3 worldDimensions;
    public static void SetDefaultParameters()
    {
        Time.timeScale = 1f;
        gameRunnig = true;
        SetWorldDimensions();
        LoadSettings();
    }
   
    public static void SetDefaultSettings()
    {
        spawnInterval = 1.2f;
        fallAccelerate = 0.1f;
        playerSpeed = 3f;
    }
    public static void SaveSettings()
    {
        PlayerPrefs.SetFloat("playerSpeed", playerSpeed);
        PlayerPrefs.SetFloat("fallAccelerate", fallAccelerate);
        PlayerPrefs.SetFloat("spawnInterval", spawnInterval);
    }

    public static void LoadSettings()
    {
        if(PlayerPrefs.HasKey("playerSpeed") && PlayerPrefs.HasKey("fallAccelerate") && PlayerPrefs.HasKey("spawnInterval"))
        {
            playerSpeed = PlayerPrefs.GetFloat("playerSpeed");
            fallAccelerate = PlayerPrefs.GetFloat("fallAccelerate");
            spawnInterval = PlayerPrefs.GetFloat("spawnInterval");
        }
        else
        {
            SetDefaultSettings();
        }
    }

    public static Vector3 SetWorldDimensions()
    {
        worldDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        return worldDimensions;
    }
}
