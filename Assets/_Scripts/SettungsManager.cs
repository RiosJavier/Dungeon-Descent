using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    public float volume = 0.5f;
    public float sensitivity = 2.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        sensitivity = PlayerPrefs.GetFloat("Sensitivity", 2.0f);
    }
}
