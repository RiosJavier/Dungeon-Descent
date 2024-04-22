using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ControlsConfiguration : MonoBehaviour
{
    private const string ControlTypeKey = "ControlType";
    private const int ArrowKeys = 1;
    private const int WASDKeys = 2;
    private bool useArrowKeys; // Added variable to track control type

    void Awake()
    {
        // Load control type from PlayerPrefs
        int controlType = PlayerPrefs.GetInt(ControlTypeKey, ArrowKeys);
        useArrowKeys = (controlType == ArrowKeys); // Set useArrowKeys based on PlayerPrefs
        SetControlType(useArrowKeys);
    }

    public void SetUseArrowKeys(bool useArrows)
    {
        int controlType = useArrows ? ArrowKeys : WASDKeys;
        SetControlType(useArrows);
        PlayerPrefs.SetInt(ControlTypeKey, controlType);
    }

    private void SetControlType(bool useArrowKeys)
    {
        this.useArrowKeys = useArrowKeys; // Update useArrowKeys
        if (useArrowKeys)
        {
            // Arrow key inputs
            Debug.Log("Using arrow keys.");
        }
        else
        {
            // WASD inputs
            Debug.Log("Using WASD keys.");
        }
    }

    void Update()
    {
        if (useArrowKeys)
        {
            // Check for arrow key inputs
            if (Input.GetKey(KeyCode.UpArrow)) { /* Move up */ }
            if (Input.GetKey(KeyCode.DownArrow)) { /* Move down */ }
            if (Input.GetKey(KeyCode.LeftArrow)) { /* Move left */ }
            if (Input.GetKey(KeyCode.RightArrow)) { /* Move right */ }
        }
        else
        {
            // Check for WASD inputs
            if (Input.GetKey(KeyCode.W)) { /* Move up */ }
            if (Input.GetKey(KeyCode.S)) { /* Move down */ }
            if (Input.GetKey(KeyCode.A)) { /* Move left */ }
            if (Input.GetKey(KeyCode.D)) { /* Move right */ }
        }
    }
}
