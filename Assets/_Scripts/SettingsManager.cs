using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private const string VolumeKey = "Volume";
    private const string SensitivityKey = "Sensitivity";

    public static void SaveSettings(float volume, float sensitivity)
    {
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.SetFloat(SensitivityKey, sensitivity);
    }

    public static void LoadSettings(out float volume, out float sensitivity)
    {
        volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f); // Default volume if not set
        sensitivity = PlayerPrefs.GetFloat(SensitivityKey, 0.5f); // Default sensitivity if not set
    }
}
