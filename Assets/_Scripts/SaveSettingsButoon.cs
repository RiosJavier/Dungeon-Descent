using UnityEngine;
using UnityEngine.UI;

public class SaveSettingsButton : MonoBehaviour
{
    public SettingsManager settingsManager;

    void Start()
    {
        // Ensure the SettingsManager is assigned
        if (settingsManager == null)
        {
            Debug.LogError("SettingsManager not assigned to SaveSettingsButton!");
            return;
        }

        // Get a reference to the button component
        Button button = GetComponent<Button>();
        // Add a listener to the button click event
        button.onClick.AddListener(SaveSettings);
    }

    void SaveSettings()
    {
        // Call the SaveSettings method in the SettingsManager
        settingsManager.SaveSettings();
        Debug.Log("Settings saved!");
    }
}