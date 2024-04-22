using UnityEngine;
using UnityEngine.UI;

public class CustomControlsConfiguration : MonoBehaviour
{
    public Text actionText;
    public Button remapButton;

    private string currentAction;
    private KeyCode currentKeyCode;

    private void Awake()
    {
        LoadPlayerPreferences();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    currentKeyCode = keyCode;
                    SavePlayerPreferences();
                    UpdateUI();
                    break;
                }
            }
        }
    }

    public void RemapKey()
    {
        remapButton.interactable = false;
        actionText.text = "Press a key to remap...";
    }

    private void SavePlayerPreferences()
    {
        PlayerPrefs.SetString(currentAction, currentKeyCode.ToString());
    }

    private void LoadPlayerPreferences()
    {
        currentAction = "Jump";
        currentKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(currentAction, "Space"));
        UpdateUI();
    }

    private void UpdateUI()
    {
        actionText.text = currentAction + ": " + currentKeyCode.ToString();
        remapButton.interactable = true;
    }
}