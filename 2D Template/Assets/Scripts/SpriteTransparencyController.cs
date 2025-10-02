using UnityEngine;
using UnityEngine.UI;

public class SpriteTransparencyController : MonoBehaviour
{
    public GameObject currentGameObject;
    public float alpha = 0.5f; //half transparency
    private Material currentMat;

    void Start()
    {
        currentGameObject = gameObject;
        currentMat = currentGameObject.GetComponent<Renderer>().material;

    }

    void Update()
    {
        //ChangeAlpha(currentMat, alpha);
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }

    public void ChangeAlphaOnValueChange(Slider slider)
    {
        ChangeAlpha(currentMat, slider.value);
    }
}
