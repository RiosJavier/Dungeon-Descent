using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject SettingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameLevel");
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    public void SettingsButton()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Debug.Log("QUIT");
        Application.Quit();
    }
}
