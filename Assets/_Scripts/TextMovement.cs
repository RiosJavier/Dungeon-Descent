using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text; // Reference to the TextMesh Pro UI text component
    public float zoomInScale = 1.5f; // The scale to zoom in to
    public float zoomOutScale = 1.0f; // The original scale to zoom out to
    public float zoomDuration = 1.5f; // Duration of the zoom in/out
    public float delayBetweenZooms = .5f; // Delay between zoom in and zoom out

    void Start()
    {
        // Start the zooming animation
        ZoomIn();
    }

    void ZoomIn()
    {
        LeanTween.scale(text.rectTransform, Vector3.one * zoomInScale, zoomDuration)
            .setOnComplete(ZoomOut) // Callback to zoom out after zoom in completes
            .setEase(LeanTweenType.easeInOutSine); // Smooth easing
    }

    void ZoomOut()
    {
        LeanTween.scale(text.rectTransform, Vector3.one * zoomOutScale, zoomDuration)
            .setOnComplete(() => 
            {
                // Add a delay before the next zoom-in
                LeanTween.delayedCall(delayBetweenZooms, ZoomIn);
            })
            .setEase(LeanTweenType.easeInOutSine); // Smooth easing
    }

}
