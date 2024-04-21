using UnityEngine;
using System.Collections; // Required for IEnumerator and coroutines

public class MenuAnimator : MonoBehaviour
{
    public float animationDuration = 0.8f; // Duration for animations
    public Vector3 targetScale = Vector3.one; // Final scale when open
    public LeanTweenType openEaseType = LeanTweenType.easeInOutSine; // Easing type for opening
    public LeanTweenType closeEaseType = LeanTweenType.easeInBack; // Easing type for closing
    public GameObject menuToDeactivate; // Optional, menu to deactivate after closing
    public GameObject menuToActivate; // Optional, menu to activate after closing

    private void OnEnable()
    {
        AnimateOpen(); // Animate when the menu becomes active
    }

    private void AnimateOpen()
    {
        transform.localScale = Vector3.zero; // Start from zero scale
        transform.LeanScale(targetScale, animationDuration)
            .setEase(openEaseType); // Smooth opening
    }

    public void CloseAndDeactivate()
    {
        AnimateClose(); // Start closing animation
        StartCoroutine(DeactivateAfterDelay(animationDuration)); // Delay deactivation
    }

    private void AnimateClose()
    {
        transform.LeanScale(Vector3.zero, animationDuration)
            .setEase(closeEaseType); // Smooth closing
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for animation to finish
        gameObject.SetActive(false); // Deactivate this menu
        ActivateOtherMenu(); // Activate another menu, if assigned
    }

    private void ActivateOtherMenu()
    {
        if (menuToActivate != null)
        {
            menuToActivate.SetActive(true); // Activate another menu
        }
    }
}