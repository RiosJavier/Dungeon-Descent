using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject SettingsMenu;
    public GameObject VolumeMenu;
    public GameObject ControlsMenu;  

    public void QuitButton()
    {
        // Quit Game
        Debug.Log("QUIT");
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("MateoEXScene");
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        CreditsMenu.SetActive(true);
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        VolumeMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        Debug.Log("Credits button clicked");
    }

    public void SettingsButton()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        VolumeMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        Debug.Log("Settings button clicked");
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        CreditsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        VolumeMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        MainMenu.SetActive(true);
        Debug.Log("Main Menu button clicked");
    }
    public void VolumeMenuButton()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        VolumeMenu.SetActive(true);
        Debug.Log("Volume Menu button clicked");
    }

    public void ControlsMenuButton()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        VolumeMenu.SetActive(false);
        ControlsMenu.SetActive(true);
        Debug.Log("Controls Menu button clicked");
    }


}
