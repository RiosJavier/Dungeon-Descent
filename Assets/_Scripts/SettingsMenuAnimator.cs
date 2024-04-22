using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public float animationDuration = 0.8f; // Duration for the animation
    public Vector3 targetScale = Vector3.one; // Final scale (1, 1, 1)
    public GameObject mainMenu;
    private void OnEnable()
    {
        // Start the animation when the GameObject is activated
        AnimateOpen();
    }

    private void AnimateOpen()
    {
        // Set the initial scale to zero
        transform.localScale = Vector3.zero;

        // Use LeanTween to scale to the target scale
        transform.LeanScale(targetScale, animationDuration)
            .setEase(LeanTweenType.easeInOutSine); // Optional easing
    }
    public void CloseAndDeactivate()
    {
        AnimateClose(); // Animate close
        StartCoroutine(DeactivateAfterDelay(animationDuration)); // Deactivate after delay
    }
    public void AnimateClose()
    {
        transform.LeanScale(Vector3.zero, animationDuration)
            .setEase(LeanTweenType.easeInBack); // Smooth closing
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for animation to finish
        gameObject.SetActive(false); // Deactivate settings menu
        ActivateMainMenu(); // Deactivate after delay
    }
     private void ActivateMainMenu()
    {
        if (mainMenu != null)
        {
            mainMenu.SetActive(true); // Activate the main menu
        }
    }

    
}
