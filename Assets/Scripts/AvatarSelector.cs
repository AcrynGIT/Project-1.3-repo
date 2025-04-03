using UnityEngine;
using UnityEngine.UI;

public class AvatarSelector : MonoBehaviour
{
    public Image avatarImage; // De UI Image component waar het dier wordt weergegeven
    public Sprite[] avatars; // Array van dier sprites
    private int currentIndex = 0;

    // Voeg een array toe voor aangepaste groottes
    public Vector2[] avatarSizes;

    void Start()
    {
        UpdateAvatar();
    }

    public void NextAvatar()
    {
        currentIndex = (currentIndex + 1) % avatars.Length;
        UpdateAvatar();
    }

    public void PreviousAvatar()
    {
        currentIndex = (currentIndex - 1 + avatars.Length) % avatars.Length;
        UpdateAvatar();
    }

    private void UpdateAvatar()
    {
        avatarImage.sprite = avatars[currentIndex];
        avatarImage.rectTransform.sizeDelta = avatarSizes[currentIndex]; // Pas de grootte aan
    }
}
