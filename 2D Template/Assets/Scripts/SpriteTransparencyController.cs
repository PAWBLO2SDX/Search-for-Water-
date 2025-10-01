using UnityEngine;
using UnityEngine.UI;

public class SpriteTransparencyController : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer;
    public Slider transparencySlider;

    void Start()
    {
        // Set the initial slider value to match the sprite's current alpha
        if (targetSpriteRenderer != null && transparencySlider != null)
        {
            transparencySlider.value = targetSpriteRenderer.color.a;
            // Add a listener to the slider's OnValueChanged event
            transparencySlider.onValueChanged.AddListener(SetSpriteTransparency);
        }
    }

    public void SetSpriteTransparency(float alphaValue)
    {
        if (targetSpriteRenderer != null)
        {
            Color spriteColor = targetSpriteRenderer.color;
            spriteColor.a = alphaValue; // Update the alpha component
            targetSpriteRenderer.color = spriteColor; // Assign the new color back
        }
    }
}
