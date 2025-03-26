using UnityEngine;

public class ButtonInputMG1 : MonoBehaviour
{
    public Transform trans;

    private bool isDragging = false;

    // Add references to the normal sprite and the x-ray sprite
    public SpriteRenderer spriteRenderer; // The SpriteRenderer component
    public Sprite normalSprite;          // The normal girl sprite
    public Sprite xraySprite;            // The x-ray sprite
    public RandomDotGenerator dotGeneratorMG1; // Verwijzing naar het DotGenerator script

    // Add a flag to track whether x-ray mode is active
    private bool isXrayMode = false;

    void Update()
    {
        if (isDragging)
        {
            trans.position = GetMousePosition();
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    // Method to toggle x-ray mode when the button is clicked
    public void ToggleXrayMode()
    {
        isXrayMode = !isXrayMode;
        spriteRenderer.sprite = isXrayMode ? xraySprite : normalSprite;

        if (isXrayMode)
        {
            // Genereer een rode dot als X-ray mode wordt ingeschakeld
            dotGeneratorMG1.GenerateRedDot();
        }
        else
        {
            // Verwijder het rode puntje als X-ray mode wordt uitgeschakeld
            dotGeneratorMG1.RemoveRedDot();
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionInWorld.z = 0;
        return positionInWorld;
    }
}
