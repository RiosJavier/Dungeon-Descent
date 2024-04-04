using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnMainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}