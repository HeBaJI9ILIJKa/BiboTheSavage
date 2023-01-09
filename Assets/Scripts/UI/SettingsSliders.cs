using UnityEngine;
using UnityEngine.UI;

public class SettingsSliders : MonoBehaviour
{
    public Slider playerSpeedSlider, SpawnIntervalSlider, fallAccelerateSlider;

    private void Start()
    {
        SetSlidersValue();
        playerSpeedSlider.onValueChanged.AddListener((playerSpeedSliderListener) => {
            GameParameters.playerSpeed = playerSpeedSlider.value;
        });

        fallAccelerateSlider.onValueChanged.AddListener((fallAccelerateSliderListener) => {
            GameParameters.fallAccelerate = fallAccelerateSlider.value * 0.1f;
        });

        SpawnIntervalSlider.onValueChanged.AddListener((SpawnIntervalSliderListener) => {
            GameParameters.spawnInterval = SpawnIntervalSlider.value * 0.1f;
        });
    }

    public void SetDefaultSliders()
    {
        GameParameters.SetDefaultSettings();
        SetSlidersValue();
    }

    public void SetSlidersValue()
    {
        playerSpeedSlider.value = GameParameters.playerSpeed;
        fallAccelerateSlider.value = GameParameters.fallAccelerate * 10;
        SpawnIntervalSlider.value = GameParameters.spawnInterval * 10;
    }
}
