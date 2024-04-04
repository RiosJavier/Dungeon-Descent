using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void OnRetryPressed()
    {
        SceneManager.LoadScene("MateoEXScene");
    }
}

