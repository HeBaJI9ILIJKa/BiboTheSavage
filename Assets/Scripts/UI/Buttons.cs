using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f;

        ScreenControl.getInstance().PauseScreenSetActive(true);
    }
    public void ResumeGame()
    {
        GameParameters.SaveSettings();
        Time.timeScale = 1f;

        ScreenControl.getInstance().PauseScreenSetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
