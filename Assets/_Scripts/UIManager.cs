using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sensitivitySlider;

    void Start()
    {
        LoadSettings();
    }

    public void SaveSettings()
    {
        float volume = volumeSlider.value;
        float sensitivity = sensitivitySlider.value;
        SettingsManager.SaveSettings(volume, sensitivity);
    }

    public void LoadSettings()
    {
        float volume, sensitivity;
        SettingsManager.LoadSettings(out volume, out sensitivity);
        volumeSlider.value = volume;
        sensitivitySlider.value = sensitivity;
    }

    public void OnSaveButtonClicked()
    {
        SaveSettings();
    }

    public void OnLoadButtonClicked()
    {
        LoadSettings();
    }
}