using UnityEngine;
using UnityEngine.UI;

public class LoadSettingsButton : MonoBehaviour
{
    public SettingsManager settingsManager;

    void Start()
    {
        // Ensure the SettingsManager is assigned
        if (settingsManager == null)
        {
            Debug.LogError("SettingsManager not assigned to LoadSettingsButton!");
            return;
        }

        // Get a reference to the button component
        Button button = GetComponent<Button>();
        // Add a listener to the button click event
        button.onClick.AddListener(LoadSettings);
    }

    void LoadSettings()
    {
        // Call the LoadSettings method in the SettingsManager
        settingsManager.LoadSettings();
        Debug.Log("Settings loaded!");
    }
}
