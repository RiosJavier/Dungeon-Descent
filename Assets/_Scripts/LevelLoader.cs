using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    public void LoadSceneWithTransition(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }
    private IEnumerator LoadLevel(string sceneName)
    {
        // Activate the transition effect
        transition.SetTrigger("Start");

        // Wait for the transition animation to complete
        yield return new WaitForSeconds(transitionTime);

        // Load the target scene
        SceneManager.LoadScene(sceneName);
    }

}
