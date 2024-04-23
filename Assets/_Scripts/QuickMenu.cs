using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuickMenu : MonoBehaviour
{
    public GameObject quickMenu; // Assign this to your Quick Menu canvas
    AudioManager audioManager;

    private void Start()
    {
        // Ensure the quick menu is not visible at start
        //quickMenu.SetActive(false);

    }

    private void Update()
    {
        //Debug.Log("Update is running.");
        // Toggle quick menu when ESC key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed.");
            ToggleQuickMenu();
        }
    }

    public void ToggleQuickMenu()
    {
        
        Debug.Log("ToggleQuickMenu called.");

        bool isActive = quickMenu.activeSelf;
        //Debug.Log("Quick menu is currently active: " + isActive);

        // Toggle the visibility of the quick menu
        quickMenu.SetActive(!isActive);

        // Log the new state
        //Debug.Log("Quick menu set active: " + !isActive);

        if (!isActive)
        {
            // If the quick menu is not active, activate it and unfreeze the game
            Time.timeScale = 0f;
            Debug.Log("Time scale set to 1");
        }
        else
        {
            // If the quick menu is active, deactivate it and freeze the game
            StartCoroutine(FreezeTimeScaleNextFrame());
        }
        

    }
    
    private IEnumerator FreezeTimeScaleNextFrame()
    {
        // Wait until the end of the frame after all rendering is done
        yield return new WaitForEndOfFrame();

        // Now freeze the game
        Time.timeScale = 1f;
        Debug.Log("Time scale set to 0");
    }
    


    public void BackToMainMenu()
    {
        // Load the main menu scene (replace "MainMenu" with your scene's name)
        audioManager.PlaySFX(audioManager.UIClick);
        SceneManager.LoadScene("MainMenu");
        
        // Make sure to resume time scale in case it's paused
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        // Deactivate the quick menu and resume the game
        audioManager.PlaySFX(audioManager.UIClick);
        quickMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
}

